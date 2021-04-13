using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.UniComment
{
    public class UniCommentForListDTO
    {
        public int Id { get; set; }
        
        [StringLength(200,MinimumLength=1,ErrorMessage = "Yorum içerik alanı en az 1 en fazla 200 karakterden oluşabilir..")]
        public string CommentContent { get; set; }
        public int LikeCount { get; set; }
        public bool IsVisible { get; set; }
        public int UserPoint { get; set; }
        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı rozet resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string RozetUrl { get; set; }
        public bool AlreadyLiked { get; set; }
        
        [StringLength(35,MinimumLength=6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 35 karakterden oluşabilir..")]
        public string UserName { get; set; }
        public int UserId { get; set; }
        public bool IsFavorite { get; set; }
        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı profil resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string ImageUrl { get; set; }
        public DateTime CommentDate { get; set; }
    }
}