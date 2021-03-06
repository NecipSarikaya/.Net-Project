using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using business.Abstract;
using data.Abstract;
using entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using webapi.DTO.HelpersDTO;
using webapi.DTO.User;
using webapi.Helpers;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private IUniversityService _universityService;
        private IDepartmentService _departmentService;
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private RoleManager<Role> _roleManager;
        private SignInManager<User> _signInManager;
        private IConfiguration _configuration;
        private IEmailSender _emailSender;
        public AuthController(IEmailSender emailSender,IConfiguration configuration,SignInManager<User> signInManager,RoleManager<Role> roleManager,UserManager<User> userManager,IMapper mapper,IDepartmentService departmentService,IUniversityService universityService)
        {
            _emailSender = emailSender;
            _configuration = configuration;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _departmentService = departmentService;
            _universityService = universityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetRegisterTemplate()
        {
            
            var universities = await _universityService.GetAllByOrdered();
            var departments = await _departmentService.GetAll();
            if(universities == null)
            {
                return NotFound(new {
                    message = "Kay??tl?? ??niversite bulunamad??."
                });
            }
            if(departments == null)
            {
                return NotFound(new {
                    message = "Kay??tl?? b??l??m bulunamad??."
                });
            }
            return Ok(new GetUserForRegisterDTO()
            {
                Universities = universities,
                Departments = departments
            });
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserForRegisterDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new{
                    message = "L??tfen bilgileri do??ru formatta giriniz.."
                });
            var user = _mapper.Map<UserForRegisterDTO,User>(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var role = "kullanici";
                await _userManager.AddToRoleAsync(user,role);
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var uriBuilder = new UriBuilder("http://localhost:4200/mail-onay");
                var values = HttpUtility.ParseQueryString(string.Empty);
                values["token"] = code;
                values["userId"] = user.Id.ToString();
                uriBuilder.Query = values.ToString();
                await _emailSender.SendEmailAsync(user.Email,"Hesab??n??z?? onaylay??n",$"Hesab??n??z?? onaylamak i??in l??tfen linke <a href='{uriBuilder}'>t??klay??n??z</a>");
                return Ok(user);
            }
            return BadRequest(result.Errors);
        }
        
        [HttpPost("file/{id}")]
        public async Task<IActionResult> uploadImage(int id, [FromForm] IFormFile file)
        {
            if (file == null || id == 0)
                return BadRequest(new {
                    message = "L??tfen bir resim dosyas?? ekleyin."
                });
            if(id == 0){
                return BadRequest(new {
                    message = "Bir hata olu??tu ,l??tfen daha sonra tekrar deneyiniz.."
                });
            }
            var user = await this._userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound(new {
                    message = "Resim y??klemeye ??al????t??????n??z kullan??c?? yok veya banland??."
                });
            var extension = Path.GetExtension(file.FileName);
            var randomName = string.Format($"{Guid.NewGuid()}{extension}");
            user.ImageUrl = randomName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", randomName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            if (await _userManager.UpdateAsync(user) != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new {
                    message = "Resim y??kleme i??lemi ba??ar??s??z oldu."
                });
            }
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await this._userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                user = await this._userManager.FindByEmailAsync(model.Email);
            }
            if (user == null || user.LockoutEnd != null)
            {
                return BadRequest(new
                {
                    message = "Email yada Kullan??c?? Ad?? hatal?? veya bu siteden banland??n??z l??tfen bilgilerinizi kontrol ediniz."
                });
            }
            if(!await _userManager.IsEmailConfirmedAsync(user)){
                return BadRequest(new {
                    message="Devam edebilmek i??in l??tfen mail adresinizi onaylay??n."
                });
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                return Ok(new
                {
                    token = await GenerateJwtToken(user)
                });
            }
            return BadRequest(new
            {
                message = "Hatal?? ??ifre girdiniz l??tfen kontrol ediniz."
            });
        }
        private async  Task<string> GenerateJwtToken(User user)
        {
            if(user == null){
                return null;
            }
            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Role,(await _userManager.GetRolesAsync(user))[0]),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(tokenDescriptor);
            return TokenHandler.WriteToken(token);
        }
    
        [HttpPost("reset")]
        public async Task<IActionResult> SendResetEmail(ResetModel model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "L??tfen do??ru formatta bilgi giriniz"
                });
            var user = await _userManager.FindByEmailAsync(model.ResetEmail);
            if(user == null)
            {
                return BadRequest(new{
                    message = "Daha ??nce bu mail adresi ile kay??t olunmam????"
                });
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var uriBuilder = new UriBuilder("http://localhost:4200/sifresifirla/"+user.Id);
            var values = HttpUtility.ParseQueryString(string.Empty);
            values["token"] = token;
            uriBuilder.Query = values.ToString();

            var seri = JsonConvert.SerializeObject(token);
            await _emailSender.SendEmailAsync(
                model.ResetEmail,
                "??ifreyi S??f??rla",$"??ifrenizi s??f??rlamak i??in l??tfen linke <a href='{uriBuilder}'>t??klay??n??z</a>");
            return Ok(seri);
        }

        [HttpPost("fullreset")]
        public async Task<IActionResult> ResetPassword(UserForReset model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new {
                    message = "L??tfen bilgileri do??ru formmatta giriniz"
                });
            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user == null)
            {
                return BadRequest(new{
                    message = "Daha ??nce bu mail adresi ile kay??t olunmam????"
                });
            }
            var result = await _userManager.ResetPasswordAsync(user,model.Token,model.Password);
            if(result.Succeeded){
                return Ok();
            }else{
                return BadRequest(new {
                    message = result
                });
            }
        }

        [HttpPut("confirm")]
        public async Task<IActionResult> ConfirmEmail(UserForConfirm confirm)
        {
            if(!ModelState.IsValid)
                return BadRequest(new {
                    message = "L??tfen bilgileri do??ru formmatta giriniz"
                });
            var user = await _userManager.FindByIdAsync(confirm.Id.ToString());
            if(user == null)
            {
                return BadRequest(new{
                    message = "Daha ??nce bu mail adresi ile kay??t olunmam????"
                });
            }
            var result = await _userManager.ConfirmEmailAsync(user,confirm.Token);
            if(result.Succeeded){
                return Ok();
            }else{
                return BadRequest(new {
                    message = result
                });
            }
        }
    }
}