using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using entity;
using webapi.DTO.UniComment;

namespace webapi.DTO.UniPost
{

    public class PagedPosts{
        public PageInfo PageInfo { get; set; }
        public List<UniPostForListDTO> Posts { get; set; }
    }
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }   
    public class UniPostForListDTO
    {
        public int Id { get; set; }

        [StringLength(100,MinimumLength = 1,ErrorMessage = "Gönderi başlık alanı en az 1 en fazla 100 karakter içerebilir..")]
        public string Title { get; set; }
        
        [StringLength(250,MinimumLength = 1,ErrorMessage = "Gönderi içerik alanı en az 1 en fazla 250 karakter içerebilir..")]
        public string Content { get; set; }
        
        [StringLength(35,MinimumLength = 6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 25 karakter içerebilir..")]
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int UserPoint { get; set; }
        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı rozet resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string RozetUrl { get; set; }
        public bool IsPopular { get; set; }
        public int LikeCount { get; set; }
        public bool HasImage { get; set; }
        public bool AlreadyLiked { get; set; }
        public bool isVisible { get; set; }
        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı profil resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
        public List<UniCommentForListDTO> UniComments { get; set; } 
    }
}