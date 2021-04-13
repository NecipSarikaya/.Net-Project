using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.UniComment
{
    public class UniCommentForUpdateDTO
    {
        [StringLength(200,MinimumLength=1,ErrorMessage = "Yorum içerik alanı en az 1 en fazla 200 karakterden oluşabilir..")]
        public string CommentContent { get; set; }
        public bool IsLiked { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsReported { get; set; }    
    }
}