using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using business.Abstract;
using entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webapi.DTO.UniPost;
using webapi.Helpers;

namespace webapi.Controllers
{
    [Authorize(Roles="admin,kullanici")]
    [ApiController]
    [Route("api/[controller]")]
    public class UniPostController : ControllerBase
    {
        private IUniPostService _uniPostService;
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private IUniPostLikeService _uniPostLikeService;
        private IUniversityService _universityService;
        private IDepartmentService _departmentService;
        private IUniCommentLikeService _uniCommentLikeService;
        private IUniPostImageService _uniPostImageService;
        private IConfiguration _configuration;
        private IUniCommentService _uniCommentService;
        private string url;
        public UniPostController(IUniCommentService uniCommentService,IConfiguration configuration,IUniPostImageService uniPostImageService,IUniCommentLikeService uniCommentLikeService,IDepartmentService departmentService,IUniversityService universityService,IUniPostLikeService uniPostLikeService,UserManager<User> userManager,IMapper mapper,IUniPostService uniPostService)
        {
            _uniCommentService = uniCommentService;
            _configuration = configuration;
            _uniPostImageService = uniPostImageService;
            _uniCommentLikeService = uniCommentLikeService;
            _departmentService = departmentService;
            _universityService =  universityService;
            _uniPostLikeService = uniPostLikeService;
            _userManager = userManager;
            _mapper = mapper;
            _uniPostService = uniPostService;
            url = _configuration["Data:ImageUrl"];
        }

        [HttpGet("{uniNameUrl}")]
        public async Task<IActionResult> GetALlUniPostsByUniNameUrl(string uniNameUrl,[FromQuery]int page=1)
        {
            if(string.IsNullOrEmpty(uniNameUrl) || page == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            const int pageSize = 12;
            var user = await _userManager.GetUserAsync(User);
            var uniposts = await _uniPostService.GetAllUniPostsByUniUrl(uniNameUrl,page,pageSize);
            if(uniposts == null)
                return BadRequest(new {
                    message ="Daha önce böyle bir post paylaşılmamış"
                });
            if(user == null)
                return BadRequest(new {
                    message ="İşlem yapılmaya çalışılan kullanıcı kayıt olmamış"
                });
            var uniposts2 = _mapper.Map<List<UniPost>,List<UniPostForListDTO>>(uniposts);
            uniposts2.ForEach(async el =>{
                el.ImageUrl = url + el.ImageUrl;
                if( await _uniPostLikeService.AlreadyLiked(user.Id,el.Id) != null){
                    el.AlreadyLiked = true;
                }else{
                    el.AlreadyLiked = false;
                }
                el.RozetUrl = HelperMethods.getRozetUrl(el.UserPoint);
                el.HasImage = await _uniPostImageService.HasImage(el.Id);
                foreach (var com in el.UniComments)
                {
                    com.ImageUrl = url + com.ImageUrl;
                    if( await _uniCommentLikeService.AlreadyLiked(user.Id,com.Id) != null){
                        com.AlreadyLiked = true;
                    }else{
                        com.AlreadyLiked = false;
                    }
                    com.RozetUrl = HelperMethods.getRozetUrl(com.UserPoint);
                }
            });
            var totalitem = await _uniPostService.GetCountByUniNameUrl(uniNameUrl);
            var data = new PagedPosts(){
                    PageInfo = new PageInfo(){
                        TotalItems =  totalitem,
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalPages = this.totalPage(totalitem,pageSize)
                    },
                    Posts = uniposts2
                };
            return Ok(data);
        }
        int totalPage(int TotalItems,int ItemsPerPage)
        {
            return (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage);
        }

        [HttpGet("{uniNameUrl}/detay/{id}")]
        public async Task<IActionResult> GetALlUniPostById(string uniNameUrl,int id)
        {
            if(id == 0 || string.IsNullOrEmpty(uniNameUrl))
            {
                return BadRequest(new {
                    message = "Bir hata oluştu lütfen daha sonra tekrar deneyiniz.."
                });
            }
            var user = await _userManager.GetUserAsync(User);
            var unipost = await _uniPostService.GetUniPostById(id);
            if(unipost == null)
                return BadRequest(new {
                    message ="Daha önce böyle bir post paylaşılmamış"
                });
            if(user == null)
                return BadRequest(new {
                    message ="İşlem yapılmaya çalışılan kullanıcı kayıt olmamış"
                });
            var unipost2 = _mapper.Map<UniPost,UniPostForDetailDTO>(unipost);
            unipost2.ImageUrl = url + unipost.User.ImageUrl;
            if( await _uniPostLikeService.AlreadyLiked(user.Id,unipost2.Id) != null){
                unipost2.AlreadyLiked = true;
            }else{
                unipost2.AlreadyLiked = false;
            }
            if(unipost2.UserId == user.Id)
            {
                unipost2.IsOwner = true;
            }
            if(await _uniCommentService.GetFavorite(unipost.Id) != null)
            {
                unipost2.IsFavoriSelected = true;
            }else{
                unipost2.IsFavoriSelected = false;
            }
            unipost2.RozetUrl = HelperMethods.getRozetUrl(unipost2.UserPoint);
            unipost2.HasImage = await _uniPostImageService.HasImage(unipost2.Id); 
            var temp = await _uniPostImageService.GetImages(unipost2.Id);
                temp.ForEach(el =>{
                    el = url+temp;
                });
            unipost2.PostImageUrls = temp;
            foreach (var com in unipost2.UniComments)
            {
                com.ImageUrl = url + com.ImageUrl;
                if( await _uniCommentLikeService.AlreadyLiked(user.Id,com.Id) != null){
                    com.AlreadyLiked = true;
                }else{
                    com.AlreadyLiked = false;
                }
                com.RozetUrl = HelperMethods.getRozetUrl(com.UserPoint);
            };
            return Ok(unipost2);
        }

        [HttpGet("{uniNameUrl}/{depNameUrl}")]
        public async Task<IActionResult> GetALlUniPostsByUniDepNameUrl(string uniNameUrl,string depNameUrl,[FromQuery]int page=1)
        {
            if (!ModelState.IsValid)
                return BadRequest(new {
                    message = "Lütfen formata uygun bilgiler giriniz"
                });
            if(page == 0 || string.IsNullOrEmpty(uniNameUrl) ||string.IsNullOrEmpty(depNameUrl))
            {
                return BadRequest(new {
                    message = "Bir hata oluştu lütfen daha sonra tekrar deneyiniz.."
                });
            }
            const int pageSize = 12;
            var user = await _userManager.GetUserAsync(User);
            var department = await _departmentService.GetDepartmentByUrl(depNameUrl);
            var university = await _universityService.GetUniByUniNameUrl(uniNameUrl);
            if(university == null)
                return BadRequest(new {
                    message ="İşlem yapılmaya çalışılan üniversite daha önce oluşturulmamış"
                });
            if(user == null)
                return BadRequest(new {
                    message ="İşlem yapılmaya çalışılan kullanıcı kayıt olmamış"
                });
            if(department == null)
                return BadRequest(new {
                    message ="İşlem yapılmaya çalışılan bölüm daha önce oluşturulmamış"
                });
            if(!await _universityService.HasADepartment(university.Id,department.Id))
                return BadRequest(new
                {
                    message = university.Name +"nde aranan fakülte bulunamadı"
                });
            var uniposts = await _uniPostService.GetAllUniPostsByDepartment(uniNameUrl,depNameUrl,page,pageSize);
            if(uniposts == null)
                return Ok();
            var uniposts2 = _mapper.Map<List<UniPost>,List<UniPostForListDTO>>(uniposts);
            uniposts2.ForEach(async el =>{
                el.ImageUrl = url + el.ImageUrl;
                if( await _uniPostLikeService.AlreadyLiked(user.Id,el.Id) != null){
                    el.AlreadyLiked = true;
                }else{
                    el.AlreadyLiked = false;
                }
                el.RozetUrl = HelperMethods.getRozetUrl(el.UserPoint);
                el.HasImage = await _uniPostImageService.HasImage(el.Id);
                foreach (var com in el.UniComments)
                {
                    com.ImageUrl = url + com.ImageUrl;
                    if( await _uniCommentLikeService.AlreadyLiked(user.Id,com.Id) != null){
                        com.AlreadyLiked = true;
                    }else{
                        com.AlreadyLiked = false;
                    }
                    com.RozetUrl = HelperMethods.getRozetUrl(com.UserPoint);
                }
            });
            var totalitem = await _uniPostService.GetCountByUniDepNameUrl(uniNameUrl,depNameUrl);
            var data = new PagedPosts(){
                    PageInfo = new PageInfo(){
                        TotalItems =  totalitem,
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalPages = this.totalPage(totalitem,pageSize)
                    },
                    Posts = uniposts2
                };
            return Ok(data);
        }
        
        [HttpPut("{postId}")]
        public async Task<IActionResult> GetUniPostById(UniPostForUpdateDTO model,int postId)
        {
            if (!ModelState.IsValid)
                return BadRequest(new {
                    message = "Lütfen formata uygun bilgiler giriniz"
                });
            if(postId == 0)
            {
                return BadRequest(new {
                    message = "Bir hata oluştu lütfen daha sonra tekrar deneyiniz.."
                });
            }
            var unipost = await _uniPostService.GetById(postId);
            var user = await _userManager.GetUserAsync(User);
            if (unipost == null || user == null)
            {
                return BadRequest(new {
                    message = "Daha önce böyle bir post paylaşılmamış"
                });
            }
            if (user == null)
            {
                return BadRequest(new {
                    message = "İşlem yapılmaya çalışılan kullanıcı daha önce kayıt edilmemiş"
                });
            }
            var postlike = await _uniPostLikeService.AlreadyLiked(user.Id,postId);
            if(!string.IsNullOrEmpty(model.Title))
            {
                unipost.Title = model.Title;
            }
            if(!string.IsNullOrEmpty(model.Content)){
                unipost.Content = model.Content;
            }
            if (model.IsLiked)
            {
                if (postlike != null)
                {
                    unipost.LikeCount -= 1;
                    await _uniPostLikeService.UnLike(postlike);
                }
                else
                {
                    unipost.LikeCount += 1;
                    await _uniPostLikeService.Like(new UniPostUserLike
                    {
                        UniPostId = unipost.Id,
                        UserId = user.Id
                    });
                }
            }
            if(model.IsReported){
                if(!unipost.IsReported){
                    unipost.IsReported = true;
                }
            }
            if(await _uniPostService.Update(unipost)!= null){
                var unipost2 = _mapper.Map<UniPost,UniPostForListDTO>(unipost);
                unipost2.ImageUrl = url + unipost2.ImageUrl;
                unipost2.HasImage = await _uniPostImageService.HasImage(unipost2.Id);
                if (postlike == null)
                {
                    unipost2.AlreadyLiked = true;
                }
                else
                {
                    unipost2.AlreadyLiked = false;
                }
                return Ok(unipost2);
            }
            else{
                return BadRequest(new {
                    message = "işlem gerçekleştirilmedi"
                });
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUniPost(UniPostForCreateDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new {
                    message = "Lütfen formata uygun bilgiler giriniz"
                });
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return BadRequest(new {
                    message = "Yorum yapmaya çalışan kullanıcı daha önce kayıt olmamış"
                });
            }
            if(model.DepartmentId == 1000)
            {
                var unipost = _mapper.Map<UniPostForCreateDTO,UniPost>(model);
                var university = await _universityService.GetById(unipost.UniversityId);
                if(university == null)
                    return BadRequest(new {
                        message = "Yorum yapılmaya çalışılan üniversite daha önce oluşturulamamış"
                    });
                unipost.UserId = user.Id;
                unipost.IsVisible = true;
                if (await _uniPostService.Create(unipost) != null)
                {
                    var uniPostDTO = _mapper.Map<UniPost,UniPostForListDTO>(unipost);
                    uniPostDTO.ImageUrl = url+uniPostDTO.ImageUrl;
                    uniPostDTO.RozetUrl = HelperMethods.getRozetUrl(user.Point);
                    uniPostDTO.HasImage = await _uniPostImageService.HasImage(uniPostDTO.Id);
                    return Ok(uniPostDTO);
                }
                return BadRequest(new {
                    message = "işlem gerçekleştirilmedi"
                });          
            }else{
                var isItValid = await _universityService.HasADepartment(model.UniversityId,model.DepartmentId);
                if(!isItValid)
                    return BadRequest(new {
                        message = "Yorum yapılmaya çalışılan bölüm daha önce bu üniversite için oluşturulamamış"
                    });
                var unipost = _mapper.Map<UniPostForCreateDTO,UniPost>(model);
                var university = await _universityService.GetById(unipost.UniversityId);
                var department = await _departmentService.GetById(unipost.DepartmentId);
                if(university == null || department == null)
                    return BadRequest(new {
                        message = "Yorum yapılmaya çalışılan üniversite daha önce oluşturulamamış"
                    });
                unipost.UserId = user.Id;
                unipost.IsVisible = true;
                if (await _uniPostService.Create(unipost) != null)
                {
                    var uniPostDTO = _mapper.Map<UniPost,UniPostForListDTO>(unipost);
                    uniPostDTO.ImageUrl = url+uniPostDTO.ImageUrl;
                    uniPostDTO.RozetUrl = HelperMethods.getRozetUrl(user.Point);
                    uniPostDTO.HasImage = await _uniPostImageService.HasImage(uniPostDTO.Id);
                    return Ok(uniPostDTO);
                }
                return BadRequest(new {
                    message = "işlem gerçekleştirilmedi"
                });
            }
        }
        
        [HttpPost("upload/{postId}")]
        public async Task<IActionResult> UploadImage(int postId,[FromForm] IFormFile[] files)
        {
            if (files == null)
                return BadRequest(new {
                    message = "Lütfen bir resim dosyası ekleyin."
                });
            if(postId == 0)
            {
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            }
            var paths = new List<string>();
            foreach (var item in files)
            {
                var extension = Path.GetExtension(item.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", randomName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await item.CopyToAsync(stream);
                }
                if(await _uniPostImageService.Create(new UniPostImage{ UniPostId = postId,ImageUrl = randomName}) == null)
                {
                    return BadRequest(new {
                        message = "Resim yükleme işlemi başarısız oldu."
                    });
                }
            }
            return Ok(files);
        }
    }
}