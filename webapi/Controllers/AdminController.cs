using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using business.Abstract;
using entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapi.DTO.Admin;
using webapi.DTO.CatComment;
using webapi.DTO.Category;
using webapi.DTO.CatPost;
using webapi.DTO.Department;
using webapi.DTO.HelpersDTO;
using webapi.DTO.UniComment;
using webapi.DTO.UniDep;
using webapi.DTO.UniPost;
using webapi.DTO.University;
using webapi.DTO.User;

namespace webapi.Controllers
{
    [Authorize(Roles="admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IUniversityService _universityService;
        private IDepartmentService _departmentService;
        private IUniPostService _uniPostService;
        private UserManager<User> _userManager;
        private IUniCommentService _uniCommentService;
        private ICatPostService _catPostService;
        private ICatCommentService _catCommentService;
        private IUniDepService _uniDepService;
        private IUserService _userService;
        private IMapper _mapper;
        public AdminController(IUserService userService,IUniDepService uniDepService,ICatCommentService catCommentService,ICatPostService catPostService,IUniCommentService uniCommentService,UserManager<User> userManager,IUniPostService uniPostService,IDepartmentService departmentService,IUniversityService universityService,IMapper mapper,ICategoryService categoryService)
        {
            _userService = userService;
            _uniDepService = uniDepService;
            _catCommentService = catCommentService;
            _catPostService = catPostService;
            _uniCommentService = uniCommentService;
            _userManager = userManager;
            _uniPostService = uniPostService;
            _departmentService = departmentService;
            _universityService = universityService;
            _mapper = mapper;
            _categoryService = categoryService;
        }
        [HttpGet("category")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAll();
            if(categories == null)
                return BadRequest(new {
                    message = "Daha önce bir kategori tanımlanmamış"
                });
            else
                return Ok(categories);
        }
        
        [HttpPost("category")]
        public async Task<IActionResult> CreateCategory(CategoryForCreateDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    message = "Lütfen bilgileri doğru giriniz"
                });
            var category = _mapper.Map<CategoryForCreateDTO,Category>(model);
            if (await _categoryService.Create(category) == null)
                return BadRequest(new
                {
                    message = "Oluşturma işlemi başarısız oldu"
                });
            else
                return Ok(category);
        }
        
        [HttpPut("category/{id}")]
        public async Task<IActionResult> UpdateCategory(CategoryForCreateDTO model, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    message = "Lütfen bilgileri doğru giriniz"
                });
            if(id == 0){
                return BadRequest(new {
                    message = "Bir hata oluştu , lütfen daha sonra tekrar deneyiniz.."
                });
            }
            var category = await _categoryService.GetById(id);
            category.Name = model.Name;
            category.NameUrl = model.NameUrl;
            category.Description = model.Description;
            category.ImageUrl = model.ImageUrl;
            if (await _categoryService.Update(category) == null)
                return BadRequest(new
                {
                    message = "Güncelleme işlemi başarısız oldu"
                });
            else
                return Ok(category);
        }
        
        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var category = await _categoryService.GetById(id);
            if (category == null){
                return BadRequest(new
                {
                    message = "Böyle bir kategori daha önce yaratılmamış"
                });
            }
            else
            {
                if(await _categoryService.Delete(category) == null)
                    return BadRequest(new {
                        message ="Silme işlemi başarısız oldu"
                    });
                else
                    return Ok(category);
            }
        }
        
        [HttpGet("university")]
        public async Task<IActionResult> GetAll()
        {
            var universities = await _universityService.GetAll();
            if (universities == null)
                return NotFound(new
                {
                    message = "Kayıtlı üniversite yok"
                });
            else
                return Ok(universities);
        }
        
        [HttpGet("university/{uniNameUrl}")]
        public async Task<IActionResult> GetUniversityByNameUrl(string uniNameUrl)
        {
            if(string.IsNullOrEmpty(uniNameUrl))
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var university = await _universityService.GetUniByUniNameUrl(uniNameUrl);
            var departments = await _departmentService.GetAll();
            var have = new List<UniCatDepListDTO>();
            var nothave = new List<UniCatDepListDTO>();
            if (university == null)
                return NotFound(new
                {
                    message = "Böyle bir üniversite daha önce yaratılmamış"
                });
            else
            {
                if (departments == null)
                {
                    return NotFound(new
                    {
                        message = "Departmanler daha önce yaratılmamış"
                    });
                }
                else
                {
                    foreach (var item in departments)
                    {
                        if (await _universityService.HasADepartment(university.Id, item.Id))
                        {
                            have.Add(new UniCatDepListDTO
                            {
                                Id = item.Id,
                                Name = item.Name,
                                NameUrl = item.NameUrl
                            });
                        }
                        else
                        {
                            nothave.Add(new UniCatDepListDTO
                            {
                                Id = item.Id,
                                Name = item.Name,
                                NameUrl = item.NameUrl
                            });
                        }
                    }
                    var data = new UniversityForDetailDTO(){
                        Have = have,
                        NotHave = nothave
                    };
                    return Ok(data);
                }
            }
        }
        
        [HttpPost("university")]
        public async Task<IActionResult> CreateUniversity(UniversityForCreateDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    message = "Lütfen bilgileri doğru giriniz"
                });
            var university = _mapper.Map<UniversityForCreateDTO, University>(model);
            if (await _universityService.Create(university) == null)
                return BadRequest(new
                {
                    message = "Oluşturma işlemi başarısız oldu"
                });
            else
                return Ok(university);
        }
        
        [HttpPut("university/{id}")]
        public async Task<IActionResult> UpdateUniversity(UniversityForCreateDTO model, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    message = "Lütfen bilgileri doğru giriniz"
                });
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var university = await _universityService.GetById(id);
            university.Name = model.Name;
            university.NameUrl = model.NameUrl;
            if (await _universityService.Update(university) == null)
                return BadRequest(new
                {
                    message = "Güncelleme işlemi başarısız oldu"
                });
            else
                return Ok(university);
        }
        
        [HttpDelete("university/{id}")]
        public async Task<IActionResult> DeleteUniversity(int id)
        {
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var university = await _universityService.GetById(id);
            if (university == null)
            {
                return BadRequest(new
                {
                    message = "Böyle bir üniversite daha önce yaratılmamış"
                });
            }
            else
            {
                if (await _universityService.Delete(university) == null)
                    return BadRequest(new
                    {
                        message = "Silme işlemi başarısız oldu"
                    });
                else
                    return Ok(university);
            }
        }
        
        [HttpGet("department")]
        public async Task<IActionResult> GetAllDepartments()
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
        
        [HttpPost("department")]
        public async Task<IActionResult> CreateDepartment(DepartmentForCreateDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    message = "Lütfen bilgileri doğru giriniz"
                });
            var department = _mapper.Map<DepartmentForCreateDTO, Department>(model);
            if (await _departmentService.Create(department) == null)
                return BadRequest(new
                {
                    message = "Oluşturma işlemi başarısız oldu"
                });
            else
                return Ok(department);
        }
        
        [HttpPut("department/{id}")]
        public async Task<IActionResult> UpdateDepartment(DepartmentForCreateDTO model, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new
                {
                    message = "Lütfen bilgileri doğru giriniz"
                });
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var department = await _departmentService.GetById(id);
            department.Name = model.Name;
            department.NameUrl = model.NameUrl;
            if (await _departmentService.Update(department) == null)
                return BadRequest(new
                {
                    message = "Güncelleme işlemi başarısız oldu"
                });
            else
                return Ok(department);
        }
        
        [HttpDelete("department/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var deparment = await _departmentService.GetById(id);
            if (deparment == null)
            {
                return BadRequest(new
                {
                    message = "Böyle bir departman daha önce yaratılmamış"
                });
            }
            else
            {
                if (await _departmentService.Delete(deparment) == null)
                    return BadRequest(new
                    {
                        message = "Silme işlemi başarısız oldu"
                    });
                else
                    return Ok(deparment);
            }
        }
        
        [HttpGet("unipost")]
        public async Task<IActionResult> GetALlUniPosts()
        {
            var uniposts = await _uniPostService.GetAllAdmin();
            if(uniposts == null)
                return NotFound();
            var uniposts2 = _mapper.Map<List<UniPost>,List<UniPostAdminDTO>>(uniposts);
            return Ok(uniposts2);
        }
        
        [HttpPut("unipost/{postId}")]
        public async Task<IActionResult> UpdateUniPost(UpdateDTO model,int postId)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen doğru formatta bilgi giriniz"
                });
            if(postId == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var unipost = await _uniPostService.GetById(postId);
            if (unipost == null)
            {
                return BadRequest(new {
                    message = "Daha önce böyle bir post paylaşılmamış"
                });
            }
            unipost.IsVisible = model.IsVisible;
            unipost.IsPopular = model.IsPopular;
            unipost.IsReported = model.IsReported;
            await _uniPostService.Update(unipost);
            var unipost2 = _mapper.Map<UniPost,UniPostAdminDTO>(unipost);
            return Ok(unipost2);
        }
        
        [HttpDelete("unipost/{id}")]
        public async Task<IActionResult> DeleteUniPost(int id)
        {
            if(id == 0 )
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var uniPost = await _uniPostService.GetById(id);
            if (uniPost == null){
                return BadRequest(new
                {
                    message = "Böyle bir yorum daha önce yaratılmamış"
                });
            }
            else
            {
                if(await _uniPostService.Delete(uniPost) == null)
                    return BadRequest(new {
                        message ="Silme işlemi başarısız oldu"
                    });
                else
                    return Ok(uniPost);
            }
        }

        [HttpGet("unicomment")]
        public async Task<IActionResult> GetAllUniComments()
        {
            var comments = await _uniCommentService.GetAllUniComments();
            if (comments == null)
                return NotFound(new
                {
                    message = "Kayıtlı yorum yok"
                });
            else{
                var commentsDTO = _mapper.Map<List<UniComment>,List<UniCommentForAdminDTO>>(comments);
                return Ok(commentsDTO);
            }
        }

        [HttpPut("unicomment/{id}")]
        public async Task<IActionResult> UpdateUniComment(UpdateDTO model,int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen doğru formatta bilgi giriniz"
                });
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var uniComment = await _uniCommentService.GetById(id);
            if(uniComment == null)
            {
                return BadRequest(new{
                    message = "Böyle bir yorum daha önce yapılmamış"
                });
            }
            uniComment.IsVisible = model.IsVisible;
            uniComment.IsReported = model.IsReported;
            await _uniCommentService.Update(uniComment);
            var catComemnt2 = _mapper.Map<UniComment,UniCommentForAdminDTO>(uniComment);
            return Ok(catComemnt2);
        }
    
        [HttpDelete("unicomment/{id}")]
        public async Task<IActionResult> DeleteUniComment(int id)
        {
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var uniComment = await _uniCommentService.GetById(id);
            if (uniComment == null){
                return BadRequest(new
                {
                    message = "Böyle bir yorum daha önce yaratılmamış"
                });
            }
            else
            {
                if(await _uniCommentService.Delete(uniComment) == null)
                    return BadRequest(new {
                        message ="Silme işlemi başarısız oldu"
                    });
                else
                    return Ok(uniComment);
            }
        }

        [HttpGet("catpost")]
        public async Task<IActionResult> getAllCatPost()
        {
            var catposts = await _catPostService.GetAllCatPosts();
            if (catposts == null)
            {
                return NotFound();
            }
            else
            {
                var catposts2 = _mapper.Map<List<CatPost>, List<CatPostForAdminListDTO>>(catposts);
                return Ok(catposts2);
            }
        }

        [HttpPut("catpost/{id}")]
        public async Task<IActionResult> UpdateCatPost(UpdateDTO model, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen doğru formatta bilgi giriniz"
                });
            if(id == 0 )
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var catpost = await _catPostService.GetById(id);
            if (catpost == null )
            {
                return BadRequest(new {
                    message = "Daha önce böyle bir post paylaşılmamış"
                });
            }
            catpost.IsVisible = model.IsVisible;
            catpost.IsReported = model.IsReported;
            await _catPostService.Update(catpost);
            var catpost2 = _mapper.Map<CatPost,CatPostForAdminListDTO>(catpost);
            return Ok(catpost2);
        }

        [HttpDelete("catpost/{id}")]
        public async Task<IActionResult> DeleteCatPost(int id)
        {
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var catPost = await _catPostService.GetById(id);
            if (catPost == null){
                return BadRequest(new
                {
                    message = "Böyle bir yorum daha önce yaratılmamış"
                });
            }
            else
            {
                if(await _catPostService.Delete(catPost) == null)
                    return BadRequest(new {
                        message ="Silme işlemi başarısız oldu"
                    });
                else
                    return Ok(catPost);
            }
        }
        
        [HttpGet("catcomment")]
        public async Task<IActionResult> GetAllCatComments()
        {
            var comments = await _catCommentService.GetAllCatComments();
            if (comments == null)
                return NotFound(new
                {
                    message = "Kayıtlı yorum yok"
                });
            else{
                var commentsDTO = _mapper.Map<List<CatComment>,List<CatCommentForAdminDTO>>(comments);
                return Ok(commentsDTO);
            }
        }

        [HttpPut("catcomment/{id}")]
        public async Task<IActionResult> UpdateCatComment(UpdateDTO model,int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen doğru formatta bilgi giriniz"
                });
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var catComment = await _catCommentService.GetById(id);
            if(catComment == null)
            {
                return BadRequest(new {
                    message = "Daha önce böyle bir yorum paylaşılmamış"
                });
            }
            catComment.IsVisible = model.IsVisible;
            catComment.IsReported = model.IsReported;
            await _catCommentService.Update(catComment);
            var catComemnt2 = _mapper.Map<CatComment,CatCommentForAdminDTO>(catComment);
            return Ok(catComemnt2);
        }

        [HttpDelete("catcomment/{id}")]
        public async Task<IActionResult> DeleteCatComment(int id)
        {
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var comment = await _catCommentService.GetById(id);
            if (comment == null){
                return BadRequest(new
                {
                    message = "Böyle bir yorum daha önce yaratılmamış"
                });
            }
            else
            {
                if(await _catCommentService.Delete(comment) == null)
                    return BadRequest(new {
                        message ="Silme işlemi başarısız oldu"
                    });
                else
                    return Ok(comment);
            }
        }

        [HttpPost("unidep")]
        public async Task<IActionResult> CreateUniDep(UniDepForCreateDTO model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen doğru formatta bilgi giriniz"
                });
            var uniDep = _mapper.Map<UniDepForCreateDTO,UniversityDepartment>(model);
            if(await _uniDepService.Create(uniDep) != null)
            {
                return Ok(uniDep);
            }
            return BadRequest();
        }
        
        [HttpDelete("unidep/{uniId}/{depId}")]
        public async Task<IActionResult> DeleteUniDep(int uniId,int depId)
        {
            if(uniId == 0 || depId== 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var uniDep = await _uniDepService.GetDepById(uniId,depId);
            if (uniDep == null){
                return BadRequest(new
                {
                    message = "Böyle bir bağlantı daha önce yaratılmamış"
                });
            }
            else
            {
                if(await _uniDepService.Delete(uniDep) == null)
                    return BadRequest(new {
                        message ="Silme işlemi başarısız oldu"
                    });
                else
                    return Ok(uniDep);
            }
        }
        
        [HttpGet("user")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _userService.GetAll();
            if(users == null)
                return BadRequest(new{
                    message="Henüz kayıtlı hiç bir kullanıcı yok"
                });
            else{
                var usersDTO = _mapper.Map<List<User>,List<UserForListDTO>>(users);
                return Ok(usersDTO);
            }
        }

        [HttpPut("user/{id}")]
        public async Task<IActionResult> UpdateUser(UserForAdminUpdateDTO model,int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen doğru formatta bilgi giriniz"
                });
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var user = await _userService.GetById(id);
            if(user == null)
                return BadRequest(new{
                    message="Bu id ile kayıtli kullanıcı yok"
                });
            else{
                if(model.IsBanned)
                {
                    await _userManager.SetLockoutEndDateAsync(user,DateTime.Now.AddDays(3));
                }else
                {
                    user.LockoutEnd = null;
                    await _userManager.UpdateAsync(user);
                }
                var userDTO = _mapper.Map<User,UserForListDTO>(user);
                return Ok(userDTO);
            }
        }
        
        [HttpDelete("user/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if(id == 0 )
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var user = await _userService.GetById(id);
            if(user == null)
                return BadRequest(new{
                    message="Bu id ile kayıtli kullanıcı yok"
                });
            else{
                await _userManager.DeleteAsync(user);
                return Ok(user);
            }
        }
    }
}