using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.UniComment
{
    public class UniCommentForCreateDTO
    {
        [Required(ErrorMessage = "Yorum içerik alanı girilmesi gerekiyor..")]
        [StringLength(200,MinimumLength=1,ErrorMessage = "Yorum içerik alanı en az 1 en fazla 200 karakterden oluşabilir..")]
        public string CommentContent { get; set; }
        
        [Required(ErrorMessage = "Yorum tarihi girilmesi gerekiyor..")]
        public DateTime CommentDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Üniversite seçilmesi gerekiyor..")]
        public int UniPostId { get; set; }
    }
}