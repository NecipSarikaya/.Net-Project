using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using business.Abstract;
using entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.HelpersDTO;
using webapi.DTO.University;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : ControllerBase
    {
        private IUniversityService _universityService;
        private IDepartmentService _departmenService;
        private IMapper _mapper;
        public UniversityController(IDepartmentService departmenService, IMapper mapper, IUniversityService universityService)
        {
            _departmenService = departmenService;
            _mapper = mapper;
            _universityService = universityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var universities = await _universityService.GetAllByOrdered();
            if (universities == null)
                return NotFound(new
                {
                    message = "Kayıtlı üniversite yok"
                });
            else
                return Ok(universities);
        }
        
        [Authorize(Roles="admin,kullanici")]
        [HttpGet("{uniNameUrl}")]
        public async Task<IActionResult> GetUniByUniNameUrl(string uniNameUrl)
        {
            if(string.IsNullOrEmpty(uniNameUrl)){
                return BadRequest(new {
                    message = "Bir hata oluştu, lütfen daha sonra tekrar deneyiniz.."
                });
            }
            var university = await _universityService.GetUniByUniNameUrl(uniNameUrl);
            if (university == null)
                return BadRequest();
            else
                return Ok(university);
        }
        
    }
}