using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using business.Abstract;
using entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webapi.DTO.CatComment;
using webapi.Helpers;

namespace webapi.Controllers
{
    [Authorize(Roles="admin,kullanici")]
    [ApiController]
    [Route("api/[controller]")]
    public class CatCommentController : ControllerBase
    {
        private ICatCommentService _catCommentService;
        private ICatCommentLikeService _catCommentLikeService;
        private IMapper _mapper;
        private UserManager<User> _userManager;
         private IConfiguration _configuration;
        private string url;
        public CatCommentController(IConfiguration configuration,ICatCommentLikeService catCommentLikeService,UserManager<User> userManager,IMapper mapper,ICatCommentService catCommentService)
        {
            _configuration = configuration;
            _catCommentLikeService = catCommentLikeService;
            _userManager = userManager;
            _mapper = mapper;
            _catCommentService = catCommentService;
            url = _configuration["Data:ImageUrl"];
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateCatComment(CatCommentForCreateDTO model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message =" Lütfen doğru formatta bilgileri giriniz.."
                });
            var comment = _mapper.Map<CatCommentForCreateDTO,CatComment>(model);
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
                return BadRequest();
            comment.IsVisible = true;
            comment.UserId = user.Id;
            if(await _catCommentService.Create(comment) != null)
            {
                var comemntDTO = _mapper.Map<CatComment,CatCommentsForListDTO>(comment);
                comemntDTO.ImageUrl = url + user.ImageUrl;
                comemntDTO.RozetUrl = HelperMethods.getRozetUrl(user.Point);
                return Ok(comemntDTO);
            }
            return BadRequest(new {
                message = "işlem gerçekleştirilmedi"
            });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCatComment(CatCommentForUpdateDTO model,int id,[FromQuery]int userId=0)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen formata uygun bir şekilde bilgileri giriniz.."
                });
            if(id == 0)
                return BadRequest(new {
                    message = "Bir hata oluştu ,lütfen daha sonra tekrar deneyiniz.."
                });
            var catComment = await _catCommentService.GetById(id);
            var user = await _userManager.GetUserAsync(User);
            if(catComment == null)
            {
                return BadRequest(new {
                    message = "Daha önce böyle bir yorum paylaşılmamış"
                });
            }
            if(user == null)
            {
                return BadRequest(new {
                    message = "İşlem yapılmaya çalışılan kullanıcı daha önce kayıt edilmemiş"
                });
            }
            var commentlike = await _catCommentLikeService.AlreadyLiked(user.Id,id);
            if(!string.IsNullOrEmpty(model.CommentContent)){
                catComment.CommentContent = model.CommentContent;
            }
            if(model.IsLiked)
            {
                if(commentlike != null)
                {
                    catComment.LikeCount -= 1;
                    await _catCommentLikeService.UnLike(commentlike);
                }else{
                    catComment.LikeCount +=1;
                    await _catCommentLikeService.Like(new CatCommentUserLike{
                        CatCommentId = catComment.Id,
                        UserId = user.Id
                    });
                }
            }
            var commentFavorite = await _catCommentService.GetFavorite(catComment.CatPostId);
           if(model.IsFavorite)
            {
                if(commentFavorite == null)
                {
                    catComment.IsFavorite = true;
                    var commentUser = await _userManager.FindByIdAsync(userId.ToString());
                    commentUser.Point++;
                    await _userManager.UpdateAsync(commentUser);
                }
            }
            if (model.IsReported)
            {
                if(!catComment.IsReported){
                    catComment.IsReported = true;
                }
            }
            if(await _catCommentService.Update(catComment) != null){
                var catComemnt2 = _mapper.Map<CatComment,CatCommentsForListDTO>(catComment);
                if(commentlike == null)
                {
                    catComemnt2.AlreadyLiked = true;
                }else{
                    catComemnt2.AlreadyLiked = false;
                }
                return Ok(catComemnt2);
            }else{
                return BadRequest(new {
                    message = "İşlem gerçekleştirilmedi"
                });
            }
        }
        
    }
}