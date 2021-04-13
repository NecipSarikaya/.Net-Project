using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using business.Abstract;
using entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using webapi.DTO.UniComment;
using webapi.Helpers;

namespace webapi.Controllers
{
    [Authorize(Roles="admin,kullanici")]
    [ApiController]
    [Route("api/[controller]")]
    public class UniCommentController:ControllerBase
    {
        private IUniCommentService _uniCommentService;
        private IUniCommentLikeService _uniCommentLikeService;
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private IUserService _userService;
        private IConfiguration _configuration;
        private string url;
        public UniCommentController(IConfiguration configuration,IUserService userService,IUniCommentLikeService uniCommentLikeService,UserManager<User> userManager,IMapper mapper,IUniCommentService uniCommentService)
        {
            _configuration = configuration;
            _userService = userService;
            _uniCommentLikeService = uniCommentLikeService;
            _userManager = userManager;
            _mapper = mapper;
            _uniCommentService = uniCommentService;
             url = _configuration["Data:ImageUrl"];
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateUniComment(UniCommentForCreateDTO model)
        {
            if(!ModelState.IsValid)
                return BadRequest(new{
                    message = "Lütfen formata uygun yorum yapınız"
                });
            var comment = _mapper.Map<UniCommentForCreateDTO,UniComment>(model);
            var user = await _userManager.GetUserAsync(User);
            if(user == null)
                return BadRequest(new{
                    message = "Yorum yapmaya çalışan kullanıcı daha önce kayıt olmamış ya da banlanmış"
                });
            comment.IsVisible = true;
            comment.UserId = user.Id;
            if(await _uniCommentService.Create(comment) != null)
            {
                var commentDTO = _mapper.Map<UniComment,UniCommentForListDTO>(comment);
                commentDTO.ImageUrl = url + commentDTO.ImageUrl;
                commentDTO.RozetUrl = HelperMethods.getRozetUrl(user.Point);
                return Ok(commentDTO);
            }
            return BadRequest(new {
                message = "işlem gerçekleştirilmedi"
            });
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCatComment(UniCommentForUpdateDTO model,int id,[FromQuery]int userId=0)
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
            var user = await _userManager.GetUserAsync(User);
            if(uniComment == null)
            {
                return BadRequest(new{
                    message = "Böyle bir yorum daha önce yapılmamış"
                });
            }
            if(user == null)
            {
                return BadRequest(new{
                    message = "İşlem yapılmaya çalışılan kullanıcı daha önce kayıt edilmemiş"
                });
            }
            var commentlike = await _uniCommentLikeService.AlreadyLiked(user.Id,id); 
            if(!string.IsNullOrEmpty(model.CommentContent)){
                uniComment.CommentContent = model.CommentContent;
            }
            if(model.IsLiked)
            {
                if(commentlike != null)
                {
                    uniComment.LikeCount -= 1;
                    await _uniCommentLikeService.UnLike(commentlike);
                }else{
                    uniComment.LikeCount +=1;
                    await _uniCommentLikeService.Like(new UniCommentUserLike{
                        UniCommentId = uniComment.Id,
                        UserId = user.Id
                    });
                }
            }
            var commentFavorite = await _uniCommentService.GetFavorite(uniComment.UniPostId);
            if(model.IsFavorite)
            {
                if(commentFavorite == null)
                {
                    uniComment.IsFavorite = true;
                    var commentUser = await _userManager.FindByIdAsync(userId.ToString());
                    commentUser.Point++;
                    await _userManager.UpdateAsync(commentUser);
                }
            }
            if(model.IsReported)
            {
                if(!uniComment.IsReported)
                {
                    uniComment.IsReported = true;
                }
            }
            if(await _uniCommentService.Update(uniComment)!= null)
            {
                var uniComment2 = _mapper.Map<UniComment,UniCommentForListDTO>(uniComment);
                if(commentlike == null)
                {
                    uniComment2.AlreadyLiked = true;
                }else{
                    uniComment2.AlreadyLiked = false;
                }
                return Ok(uniComment2);
            }
            else{
                return BadRequest(new {
                    message = "işlem gerçekleştirilmedi"
                });
            }
        }
        
    }
}