using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.CatPost
{
    public class CatPostForAdminListDTO
    {
        public int Id { get; set; }
        
        [StringLength(100,MinimumLength=1,ErrorMessage = "Gönderi başlık alanı en az 1 en fazla 100 karakter içerebilir...")]
        public string Title { get; set; }
        
        [StringLength(250,MinimumLength=1,ErrorMessage = "Gönderi içerik alanı en az 1 en fazla 250 karakter içerebilir...")]
        public string Content { get; set; }
        public bool IsVisible { get; set; }
        public bool IsReported { get; set; }

        [StringLength(35,MinimumLength=6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 35 karakter içerebilir...")]
        public string UserName { get; set; }
    }
}