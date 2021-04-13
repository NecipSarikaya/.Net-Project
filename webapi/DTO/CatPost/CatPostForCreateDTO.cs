using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.CatPost
{
    public class CatPostForCreateDTO
    {
        [Required(ErrorMessage = "Gönderi başlık alanı boş bırakılamaz..")]
        [StringLength(100,MinimumLength=1,ErrorMessage = "Gönderi başlık alanı en az 1 en fazla 100 karakter içerebilir...")]
        public string Title { get; set; }

        [StringLength(250,MinimumLength=1,ErrorMessage = "Gönderi içerik alanı en az 1 en fazla 250 karakter içerebilir...")]
        [Required(ErrorMessage = "Gönderi içerik alanı boş bırakılamaz..")]
        public string Content  { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;
    }
}