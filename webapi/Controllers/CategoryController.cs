using System.Threading.Tasks;
using AutoMapper;
using business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController:ControllerBase
    {
        private ICategoryService _categoryService;
        private IMapper _mapper;
        public CategoryController(IMapper mapper,ICategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();
            if (categories == null)
                return NotFound(new
                {
                    message = "Kayıtlı kategori yok"
                });
            else
                return Ok(categories);
        }
        
        [Authorize(Roles="admin,kullanici")]
        [HttpGet("{catNameUrl}")]
        public async Task<IActionResult> GetCategoryByNameUrl(string catNameUrl)
        {
            if(string.IsNullOrEmpty(catNameUrl))
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var category = await _categoryService.GetCategoryByNameUrl(catNameUrl);
            if(category == null)
                return NotFound();
            else
                return Ok(category);
        }

    }
}