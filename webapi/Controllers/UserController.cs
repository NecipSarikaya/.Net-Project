using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using AutoMapper;
using business.Abstract;
using entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using webapi.DTO.CatPost;
using webapi.DTO.UniPost;
using webapi.DTO.User;
using webapi.Helpers;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private UserManager<User> _userManager;
        private IUniPostLikeService _uniPostLikeService;
        private ICatPostLikeService _catPostLikeService;
        private IUniPostService _uniPostService;
        private ICatPostService _catPostService;
        private IUserFollowUserService _userFollowUserService;
        private IMapper _mapper;
        private IConfiguration _configuration;
        private IEmailSender _emailSender;
        private string url;
        public UserController(IEmailSender emailSender,IConfiguration configuration,IUserFollowUserService userFollowUserService,ICatPostService catPostService,IUniPostService uniPostService,ICatPostLikeService catPostLikeService,IUniPostLikeService uniPostLikeService,UserManager<User> userManager,IMapper mapper,IUserService userService)
        {
            _emailSender = emailSender;
            _configuration = configuration;
            _userFollowUserService = userFollowUserService;
            _catPostService = catPostService;
            _uniPostService = uniPostService;
            _catPostLikeService = catPostLikeService;
            _uniPostLikeService = uniPostLikeService;
            _userManager = userManager;
            _mapper = mapper;
            _userService = userService;
            url = _configuration["Data:ImageUrl"];
        }
        [HttpGet("reset/{id}")]
        public async Task<IActionResult> GetResetUser(int id)
        {
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu, lütfen daha sonra tekrar deneyniz.."
                });
            var user = await _userService.GetById(id);
            if(user == null)
                return BadRequest(new {
                    message = "Daha önce böyle bir kullanıcı oluşturulmamış"
                });
            else
                return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu, lütfen daha sonra tekrar deneyniz.."
                });
            var user = await _userService.GetUpdateUser(id);
            var currentUser = await _userManager.GetUserAsync(User);
            if(user == null)
                return BadRequest(new{
                    message = "Daha önce böyle bir kullanıcı oluşturulmamış"
                });
           
            if(currentUser == null){
                return BadRequest(new{
                    message = "Lütfen önce giriş yapınız"
                });
            }
            
            if(user.Id == currentUser.Id){
                var userDTO = _mapper.Map<User,UserForGuestProfile>(user);
                var following = await _userFollowUserService.GetFollowings(id);
                var followings = _mapper.Map<List<User>,List<UserForFollowList>>(following);
                var follower = await _userFollowUserService.GetFollowers(id);
                var followers = _mapper.Map<List<User>,List<UserForFollowList>>(follower);
                foreach (var item in followings)
                {
                    item.isAlreadyFollowed = await _userFollowUserService.IsAlreadyFollowed(currentUser.Id,item.Id);
                }
                foreach (var item in followers)
                {
                    item.isAlreadyFollowed = await _userFollowUserService.IsAlreadyFollowed(currentUser.Id,item.Id);
                }
                userDTO.IsCurrentUser = true;
                userDTO.Followers = followers;
                userDTO.Followings = followings;
                userDTO.BadgeUrl = HelperMethods.getRozetUrl(user.Point);
                return Ok(userDTO);
            }else{
                var userDTO = _mapper.Map<User,UserForProfileDTO>(user);
                userDTO.IsCurrentUser = false;
                userDTO.IsAlreadyFollowed = await _userFollowUserService.IsAlreadyFollowed(currentUser.Id,user.Id);
                var following = await _userFollowUserService.GetFollowings(id);
                var followings = _mapper.Map<List<User>,List<UserForGuestFollowList>>(following);
                var follower = await _userFollowUserService.GetFollowers(id);
                var followers = _mapper.Map<List<User>,List<UserForGuestFollowList>>(follower);
                foreach (var item in followings)
                {
                    if(item.Id == currentUser.Id){
                        item.isCurrentUser = true;
                    }
                    item.ImageUrl = url + item.ImageUrl;
                    item.isAlreadyFollowed = await _userFollowUserService.IsAlreadyFollowed(currentUser.Id,item.Id);
                }
                foreach (var item in followers)
                {
                    if(item.Id == currentUser.Id){
                        item.isCurrentUser = true;
                    }
                    item.ImageUrl = url + item.ImageUrl;
                    item.isAlreadyFollowed = await _userFollowUserService.IsAlreadyFollowed(currentUser.Id,item.Id);
                }
                userDTO.IsCurrentUser = false;
                userDTO.Followers = followers;
                userDTO.Followings = followings;
                userDTO.BadgeUrl = HelperMethods.getRozetUrl(user.Point);
                return Ok(userDTO);
            }            
        }

        [Authorize(Roles="kullanici,admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(UserForUpdateDTO model,int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(new {
                    message = "Lütfen girilen bilgileri kontrol ediniz"
                });
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu, lütfen daha sonra tekrar deneyniz.."
                });
            var user = await _userService.GetById(id);
            if(user == null)
                return BadRequest(new{
                    message = "Daha önce böyle bir kullanıcı oluşturulmamış"
                });
            else
            {
                if(string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.UserName))
                    return BadRequest(new {
                        message = "Lütfen bilgileri eksiksiz girin"
                    });
                var control = false;
                user.Name = model.Name;
                user.LastName = model.LastName;
                user.UserName = model.UserName;
                user.UniversityId = model.UniversityId;
                user.DepartmentId = model.DepartmentId;
                user.Gender = model.Gender;
                user.InstagramLink = model.InstagramLink;
                user.TwitterLink = model.TwitterLink;
                user.About = model.About;
                if(model.Email != user.Email){
                    user.Email = model.Email;
                    user.EmailConfirmed = false;
                    control = true;
                }
                if(await _userManager.UpdateAsync(user) != null){
                    var userDTO = _mapper.Map<User,UserForUpdateDTO>(user);
                    if(control){
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var uriBuilder = new UriBuilder("http://localhost:4200/mail-onay");
                        var values = HttpUtility.ParseQueryString(string.Empty);
                        values["token"] = code;
                        values["userId"] = user.Id.ToString();
                        uriBuilder.Query = values.ToString();
                        await _emailSender.SendEmailAsync(user.Email,"Hesabınızı onaylayın",$"Hesabınızı onaylamak için lütfen linke <a href='{uriBuilder}'>tıklayınız</a>");
                        userDTO.IsEmailChanged = true;
                    }else{
                        userDTO.IsEmailChanged = false;
                    }
                    return Ok(userDTO);
                }else{
                    return BadRequest(new {
                        message = "İşlem gerçekleştirilmedi"
                    });
                }
                
            }
        }
    
        [Authorize(Roles="kullanici,admin")]
        [HttpGet("published/{id}")]
        public async Task<IActionResult> GetPublishedPosts(int id)
        {
            if(id == 0){
                return BadRequest(new {
                    message = "Bir hata oluştu, lütfen daha sonra tekrar deneyniz.."
                });
            }
            var uniposts = await _userService.GetPublishedPosts(id);
            var unipostsDTO = _mapper.Map<List<UniPost>,List<UniPostForProfileListDTO>>(uniposts);
            unipostsDTO.ForEach(async el =>{
                if( await _uniPostLikeService.AlreadyLiked(id,el.Id) != null){
                    el.AlreadyLiked = true;
                }else{
                    el.AlreadyLiked = false;
                }
            });
            var catposts = await _userService.GetPublishedCatPosts(id);
            var catpostsDTO = _mapper.Map<List<CatPost>,List<CatPostForProfileListDTO>>(catposts);
            catpostsDTO.ForEach(async el =>{
                if( await _catPostLikeService.AlreadyLiked(id,el.Id) != null){
                    el.AlreadyLiked = true;
                }else{
                    el.AlreadyLiked = false;
                }
            });
            var model = new {
                Uniposts = unipostsDTO,
                Catposts = catpostsDTO
            };
            return Ok(model);
        }
       
        [Authorize(Roles="kullanici,admin")]
        [HttpGet("liked/{id}")]
        public async Task<IActionResult> GetLikedUniPosts(int id)
        {
            if(id == 0){
                return BadRequest(new {
                    message = "Bir hata oluştu, lütfen daha sonra tekrar deneyniz.."
                });
            }
            var uniposts = await _uniPostService.GetAllUniPosts();
            var uniPostData = new List<UniPostForProfileListDTO>();
            var unipostsDTO = _mapper.Map<List<UniPost>,List<UniPostForProfileListDTO>>(uniposts);
            unipostsDTO.ForEach(async el =>{
                if( await _uniPostLikeService.AlreadyLiked(id,el.Id) != null){
                    el.AlreadyLiked = true;
                    uniPostData.Add(el);
                }else{
                    el.AlreadyLiked = false;
                }
            });
            var catposts = await _catPostService.GetAllCatPosts();
            var catPostData = new List<CatPostForProfileListDTO>();
            var catpostsDTO = _mapper.Map<List<CatPost>,List<CatPostForProfileListDTO>>(catposts);
            catpostsDTO.ForEach(async el =>{
                if( await _catPostLikeService.AlreadyLiked(id,el.Id) != null){
                    el.AlreadyLiked = true;
                    catPostData.Add(el);
                }else{
                    el.AlreadyLiked = false;
                }
            });
            var model = new {
                Uniposts = uniPostData,
                Catposts = catPostData
            };
            return Ok(model);
        }
        int totalPage(int TotalItems,int ItemsPerPage)
        {
            return (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
        }

        [Authorize(Roles="kullanici,admin")]
        [HttpPost]
        public async Task<IActionResult> FollowUser(UserForFollowDTO model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new {
                    message = "Lütfen girilen bilgileri kontrol ediniz"
                });
            if(model.UserId == model.FollowerUserId)
            {
                return BadRequest(new{
                    message="Kendinizi takip edemezsiniz"
                });
            }
            var follower = await _userService.GetById(model.FollowerUserId);
            var user = await _userService.GetById(model.UserId);
            if(follower == null)
            {
                return BadRequest(new {
                    message = "Lütfen giriş yapınız"
                });
            }
            if(user == null)
            {
                return BadRequest(new {
                    message = "Takip etmeye çalıştığınız kullanıcı daha önce oluşturulmamış"
                });
            }
            var follow = new UserFollowUser{
                FollowerId = model.FollowerUserId,
                UserId = model.UserId
            };
            if(await _userFollowUserService.IsAlreadyFollowed(model.FollowerUserId,model.UserId)){
                
                if(await _userFollowUserService.Delete(follow) == null){
                    return BadRequest(new {
                        message="Takip bırakma işlemi başarısız"
                    });
                }else{
                    var result = new{
                        user = follower,
                        result = "break"
                    };
                    return Ok(result);
                }
            }
            if(await _userFollowUserService.Create(follow) == null){
                return BadRequest(new {
                    message="Takip işlemi başarısız"
                });
            }else{
                var result = new{
                    user = follower,
                    result = "follow"
                };
                return Ok(result);
            }
        }
    }
    
}