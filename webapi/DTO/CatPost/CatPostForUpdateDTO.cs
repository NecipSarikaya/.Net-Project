using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.CatPost
{
    public class CatPostForUpdateDTO
    {
        [StringLength(100,MinimumLength=1,ErrorMessage = "Gönderi başlık alanı en az 1 en fazla 100 karakter içerebilir...")]
        public string Title { get; set; }

        [StringLength(250,MinimumLength=1,ErrorMessage = "Gönderi içerik alanı en az 1 en fazla 250 karakter içerebilir...")]
        public string Content { get; set; }
        public bool IsReported { get; set; }
        public bool IsLiked { get; set; }
    }
}