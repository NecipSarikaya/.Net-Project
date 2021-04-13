using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.CatComment
{
    public class CatCommentsForListDTO
    {
        public int Id { get; set; }
        
        [StringLength(200,MinimumLength=1,ErrorMessage="Yorum içerik adı alanı en az 1 en fazla 200 karakter içerebilir..")]
        public string CommentContent { get; set; }
        public int LikeCount { get; set; }

        [StringLength(120,MinimumLength=1,ErrorMessage="Kullanıcı rozet resmi alanı en az 1 en fazla 120 karakter içerebilir..")]
        public string RozetUrl { get; set; }
        public int UserPoint { get; set; }
        public bool IsVisible { get; set; }
        public bool AlreadyLiked { get; set; }
        public bool IsFavorite { get; set; }

        [StringLength(120,MinimumLength=1,ErrorMessage="Kullanıcı profil resmi alanı en az 1 en fazla 120 karakter içerebilir..")]
        public string ImageUrl { get; set; }
        
        [StringLength(35,MinimumLength=6,ErrorMessage="Kullanıcı adı alanı en az 6 en fazla 35 karakter içerebilir..")]
        public string UserName { get; set; }
        public int UserId { get; set; }
        public DateTime CommentDate { get; set; }
    }
}