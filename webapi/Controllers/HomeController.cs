using System.Threading.Tasks;
using business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webapi.Helpers;
using webapi.DTO.HelpersDTO;
using Microsoft.AspNetCore.Authorization;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private IEmailSender _emailSender;
        private IConfiguration _configuration;
        private IUniversityService _universityService;
        public HomeController(IUniversityService universityService, IConfiguration configuration, IEmailSender emailSender)
        {
            _universityService = universityService;
            _configuration = configuration;
            _emailSender = emailSender;
        }
        
        [HttpPost("contact")]
        public async Task<IActionResult> SendEmailToAdmin(SendMailToAdminDTO model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen doğru formatta bilgi giriniz"
                });
            await this._emailSender.SendEmailAsync(_configuration["EmailSender:UserName"], model.Title, model.Content + " " + model.Name);
            return Ok("Mailiniz bize ulaştı.Teşekkür ederiz.");
        }
    }
}