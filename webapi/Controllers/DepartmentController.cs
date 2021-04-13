using System.Threading.Tasks;
using AutoMapper;
using business.Abstract;
using entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.Department;

namespace webapi.Controllers
{
    [Authorize(Roles="admin,kullanici")]
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _departmentService;
        private IUniDepService _uniDepService;
        private IUniversityService _universityService;
        private IMapper _mapper;
        public DepartmentController(IMapper mapper, IUniversityService universityService, IDepartmentService departmentService, IUniDepService uniDepService)
        {
            _mapper = mapper;
            _universityService = universityService;
            _uniDepService = uniDepService;
            _departmentService = departmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAll();
            if (departments == null)
                return NotFound(new
                {
                    message = "Kayıtlı departman yok"
                });
            else
                return Ok(departments);
        }
        
        [HttpGet("{depNameUrl}")]
        public async Task<IActionResult> GetById(string depNameUrl)
        {

            if(string.IsNullOrEmpty(depNameUrl))
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var departments = await _departmentService.GetDepartmentByUrl(depNameUrl);
            if (departments == null)
                return NotFound(new
                {
                    message = "Böyle bir departman daha önce yaratılmamış"
                });
            else
                return Ok(departments);
        }
    }
}