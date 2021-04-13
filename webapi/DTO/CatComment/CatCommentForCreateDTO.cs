using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.CatComment
{
    public class CatCommentForCreateDTO
    {
        [Required(ErrorMessage = "Yorum içerik alanı boş bırakılamaz...")]
        [StringLength(200,MinimumLength=1,ErrorMessage="Yorum içerik adı alanı en az 1 en fazla 200 karakter içerebilir..")]
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Kategori seçilmeden yorum yapılamaz...")]
        public int CatPostId { get; set; }
    }
}