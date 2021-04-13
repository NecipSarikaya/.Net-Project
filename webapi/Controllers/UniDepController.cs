using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using business.Abstract;
using data.Abstract;
using entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.UniDep;

namespace webapi.Controllers
{
    [Authorize(Roles="admin,kullanici")]
    [ApiController]
    [Route("api/[controller]")]
    public class UniDepController:ControllerBase
    {
        private IUniDepRepository _uniDepRepository;
        private IMapper _mapper;
        private IDepartmentService _departmentService;
        private IUniversityService _universityService;
        public UniDepController(IUniversityService universityService,IDepartmentService departmentService,IMapper mapper,IUniDepRepository uniDepRepository)
        {
            _departmentService = departmentService;
            _universityService = universityService;
            _mapper = mapper;
            _uniDepRepository = uniDepRepository;
        }

        [HttpGet("{uniNameUrl}")]
        public async Task<IActionResult> GetByuniNameUrl(string uniNameUrl)
        {
            if(string.IsNullOrEmpty(uniNameUrl))
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var departments = await _departmentService.GetAll();
            var university = await _universityService.GetUniByUniNameUrl(uniNameUrl);
            var responseDepartmens = new List<Department>();
            if (departments == null || university == null)
                return NotFound(new
                {
                    message = "Böyle bir bağlantı daha önce yaratılmamış"
                });
            else{
                foreach (var item in departments)
                {
                    if(await _universityService.HasADepartment(university.Id,item.Id))
                    {
                        responseDepartmens.Add(item);
                    }
                }
                return Ok(responseDepartmens);
            }
        }
    }
}