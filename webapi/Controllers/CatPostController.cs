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
using webapi.DTO.CatPost;
using webapi.Helpers;

namespace webapi.Controllers
{
    [Authorize(Roles="admin,kullanici")]
    [ApiController]
    [Route("api/[controller]")]
    public class CatPostController : ControllerBase
    {
        private ICatPostService _catPostService;
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private ICatPostLikeService _catPostLikeService;
        private ICategoryService _categoryService;
        private ICatCommentLikeService _catCommentLikeService;
        private ICatPostImageService _catPostImageService;
        private ICatCommentService _catCommentService;
        private IConfiguration _configuration;
        private string url;
        public CatPostController(IConfiguration configuration,ICatCommentService catCommentService,ICatPostImageService catPostImageService,ICatCommentLikeService catCommentLikeService, ICategoryService categoryService, ICatPostLikeService catPostLikeService, UserManager<User> userManager, IMapper mapper, ICatPostService catPostService)
        {
            _configuration =configuration;
            _catCommentService = catCommentService;
            _catPostImageService = catPostImageService;
            _catCommentLikeService = catCommentLikeService;
            _categoryService = categoryService;
            _catPostLikeService = catPostLikeService;
            _userManager = userManager;
            _mapper = mapper;
            url = _configuration["Data:ImageUrl"];
            _catPostService = catPostService;
        }
        
        [HttpGet("{catNameUrl}")]
        public async Task<IActionResult> getAllCatPostByCategory(string catNameUrl, [FromQuery] int page = 1)
        {
            if(page == 0 || string.IsNullOrEmpty(catNameUrl))
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            const int pageSize = 12;
            var catposts = await _catPostService.GetAllCatPostByCategory(catNameUrl, page, pageSize);
            var user = await _userManager.GetUserAsync(User);
            if (catposts == null || user == null)
            {
                return BadRequest();
            }
            else
            {
                var catposts2 = _mapper.Map<List<CatPost>,List<CatPostForListDTO>>(catposts);
                catposts2.ForEach(async el =>
                {
                    el.ImageUrl = url + el.ImageUrl;
                    if (await _catPostLikeService.AlreadyLiked(user.Id, el.Id) != null)
                    {
                        el.AlreadyLiked = true;
                    }
                    else
                    {
                        el.AlreadyLiked = false;
                    }
                    el.HasImage = await _catPostImageService.GetImageByPostId(el.Id);
                    el.RozetUrl = HelperMethods.getRozetUrl(el.UserPoint);
                    el.CatComments.ForEach(async com =>
                    {
                        com.RozetUrl = HelperMethods.getRozetUrl(com.UserPoint);
                        com.ImageUrl = url + com.ImageUrl;
                        if (await _catCommentLikeService.AlreadyLiked(user.Id, com.Id) != null)
                        {
                            com.AlreadyLiked = true;
                        }
                        else
                        {
                            com.AlreadyLiked = false;
                        }
                    });
                });
                var totalItems = await _catPostService.getCatPostCountByCategory(catNameUrl);
                var data = new PagedPosts()
                {
                    PageInfo = new PageInfo()
                    {
                        TotalItems = totalItems,
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalPages = this.totalPage(totalItems, pageSize)
                    },
                    Posts = catposts2
                };
                return Ok(data);
            }
        }
        
        int totalPage(int TotalItems, int ItemsPerPage)
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
        
        [HttpGet("{catnameUrl}/{postId}")]
        public async Task<IActionResult> getCatPostById(string catnameUrl, int postId)
        {
            if(postId == 0 || string.IsNullOrEmpty(catnameUrl))
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var user = await _userManager.GetUserAsync(User);
            var catpost = await _catPostService.GetCatPostById(catnameUrl, postId);
            if (catpost == null || user == null)
            {
                return BadRequest();
            }
            else
            {
                var catpost2 = _mapper.Map<CatPost,CatPostForDetailDTO>(catpost);
                catpost2.ImageUrl = url + catpost2.ImageUrl;
                catpost2.RozetUrl = HelperMethods.getRozetUrl(catpost2.UserPoint);
                var catpostlike = await _catPostLikeService.AlreadyLiked(user.Id, catpost.Id);
                if (catpostlike != null)
                {
                    catpost2.AlreadyLiked = true;
                }
                else
                {
                    catpost2.AlreadyLiked = false;
                }
                if(catpost.UserId == user.Id){
                    catpost2.IsOwner = true;
                }
                if(await _catCommentService.GetFavorite(catpost.Id) != null)
                {
                    catpost2.IsFavoriSelected = true;
                }else{
                    catpost2.IsFavoriSelected = false;
                }
                var temp = await _catPostImageService.GetImages(catpost2.Id);
                temp.ForEach(el =>{
                    el = url+temp;
                });
                catpost2.PostImageUrls = temp;
                foreach (var item in catpost2.CatComments)
                {
                    item.ImageUrl = url + item.ImageUrl;
                    item.RozetUrl = HelperMethods.getRozetUrl(item.UserPoint);
                    if (await _catCommentLikeService.AlreadyLiked(user.Id, item.Id)!= null)
                    {
                        item.AlreadyLiked = true;
                    }
                    else
                    {
                        item.AlreadyLiked = false;
                    }
                }
                return Ok(catpost2);
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCatPost(CatPostForUpdateDTO model, int id)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen doğru formatta bilgi giriniz"
                });
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var catpost = await _catPostService.GetById(id);
            var user = await _userManager.GetUserAsync(User);
            if (catpost == null )
            {
                return BadRequest(new {
                    message = "Daha önce böyle bir post paylaşılmamış"
                });
            }
            if(user ==null)
            {
                return BadRequest(new {
                    message = "İşlem yapılmaya çalışılan kullanıcı daha önce kayıt edilmemiş"
                });
            }
            var catpostlike = await _catPostLikeService.AlreadyLiked(user.Id,id);
            if (!string.IsNullOrEmpty(model.Title))
            {
                catpost.Title = model.Title;
            }
            if (!string.IsNullOrEmpty(model.Content))
            {
                catpost.Content = model.Content;
            }
            if (model.IsLiked)
            {
                if (catpostlike != null)
                {
                    catpost.LikeCount -= 1;
                    await _catPostLikeService.UnLike(catpostlike);
                }
                else
                {
                    catpost.LikeCount += 1;
                    await _catPostLikeService.Like(new CatPostUserLike{
                        CatPostId = id,
                        UserId = user.Id
                    });
                }
            }
            if (model.IsReported)
            {
                if(!catpost.IsReported){
                    catpost.IsReported = true;
                }
            }
            if(await _catPostService.Update(catpost) != null)
            {
                var catpost2 = _mapper.Map<CatPost,CatPostForListDTO>(catpost);
                catpost2.ImageUrl = url + catpost2.ImageUrl;
                if (catpostlike == null)
                {
                    catpost2.AlreadyLiked = true;
                }
                else
                {
                    catpost2.AlreadyLiked = false;
                }
                return Ok(catpost2);
            }
            else{
                return BadRequest(new {
                    message = "işlem gerçekleştirilmedi"
                });
            }
        }
        
        [HttpPost("{catnameUrl}")]
        public async Task<IActionResult> CreateCatPost(CatPostForCreateDTO model, string catnameUrl)
        {
            if (!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen formata uygun bir şekilde bilgileri girin.."
                });
            if(string.IsNullOrEmpty(catnameUrl))
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var user = await _userManager.GetUserAsync(User);
            var category = await _categoryService.GetCategoryByNameUrl(catnameUrl);
            if (user == null || category == null)
            {
                return BadRequest();
            }
            var catpost = _mapper.Map<CatPostForCreateDTO,CatPost>(model);
            catpost.UserId = user.Id;
            catpost.CategoryId = category.Id;
            catpost.IsVisible = true;
            if (await _catPostService.Create(catpost) != null)
            {
                var catPostDTO = _mapper.Map<CatPost,CatPostForListDTO>(catpost);
                catPostDTO.ImageUrl = url + user.ImageUrl;
                catPostDTO.RozetUrl = HelperMethods.getRozetUrl(user.Point);
                catPostDTO.HasImage = await _catPostImageService.GetImageByPostId(catPostDTO.Id);
                return Ok(catPostDTO);
            }
            return BadRequest(new {
                message = "işlem gerçekleştirilmedi"
            });
        }
    
        [HttpPost("upload/{postId}")]
        public async Task<IActionResult> Test(int postId,[FromForm] IFormFile[] files)
        {
            if (files == null || postId == 0)
                return BadRequest(new {
                    message = "Lütfen bir resim dosyası ekleyin."
                });
            if(postId == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
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
                if(await _catPostImageService.Create(new CatPostImage{ CatPostId = postId,ImageUrl = randomName}) == null)
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