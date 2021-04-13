using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using webapi.DTO.CatComment;

namespace webapi.DTO.CatPost
{
    public class PagedPosts{
        public PageInfo PageInfo { get; set; }
        public List<CatPostForListDTO> Posts { get; set; }
    }
    public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
    public class CatPostForListDTO
    {
        public int Id { get; set; }

        [StringLength(100,MinimumLength=1,ErrorMessage = "Gönderi başlık alanı en az 1 en fazla 100 karakter içerebilir...")]
        public string Title { get; set; }
        
        [StringLength(35,MinimumLength=6,ErrorMessage = "Gönderi başlık alanı en az 6 en fazla 35 karakter içerebilir...")]
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int UserPoint { get; set; }

        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı profil resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string ImageUrl { get; set; }
        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı rozet resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string RozetUrl { get; set; }
        public DateTime PublishDate { get; set; }
        
        [StringLength(250,MinimumLength=1,ErrorMessage = "Gönderi içerik alanı en az 1 en fazla 250 karakter içerebilir...")]
        public string Content { get; set; }
        public int LikeCount { get; set; }
        public bool IsVisible { get; set; }
        public bool AlreadyLiked { get; set; }
        public bool HasImage { get; set; }
        public List<CatCommentsForListDTO> CatComments { get; set; }
    }
}