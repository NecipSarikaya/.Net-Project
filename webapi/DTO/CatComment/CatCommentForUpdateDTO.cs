using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.CatComment
{
    public class CatCommentForUpdateDTO
    {
        [StringLength(200,MinimumLength=1,ErrorMessage="Yorum içerik adı alanı en az 1 en fazla 200 karakter içerebilir..")]
        public string CommentContent { get; set; }
        public bool IsLiked { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsReported { get; set; }
    }
}