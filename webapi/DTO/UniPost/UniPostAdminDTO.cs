using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.UniPost
{
    public class UniPostAdminDTO
    {
        public int Id { get; set; }
        public bool IsPopular { get; set; }
        public bool IsVisible { get; set; }
        public bool IsReported { get; set; }
        
        [StringLength(100,MinimumLength = 1,ErrorMessage = "Gönderi başlık alanı en az 1 en fazla 100 karakter içermelidir..")]
        public string Title { get; set; }

        [StringLength(250,MinimumLength = 1,ErrorMessage = "Gönderi içerik alanı en az 1 en fazla 250 karakter içermelidir..")]
        public string Content { get; set; }

        [StringLength(35,MinimumLength = 6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 35 karakter içermelidir..")]
        public string UserName { get; set; }
    }
}