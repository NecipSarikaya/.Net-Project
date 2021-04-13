using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.User
{
    public class UserForListDTO
    {
        public int Id { get; set; }

        [StringLength(35,MinimumLength = 3,ErrorMessage = "Ad alanı en az 3 en fazla 35 karakter içerebilir..")]
        public string Name { get; set; }
        
        [StringLength(35,MinimumLength = 2,ErrorMessage = "Soyad alanı en az 3 en fazla 35 karakter içerebilir..")]
        public string LastName { get; set; }
        
        [StringLength(35,MinimumLength = 6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 35 karakter içerebilir..")]
        public string UserName { get; set; }
        
        [EmailAddress(ErrorMessage = "Girilen bilgi email formatında değil..")]
        [StringLength(40,MinimumLength = 11,ErrorMessage = "Email alanı en az 11 en fazla 40 karakter içerebilir..")]
        public string Email { get; set; }
        public bool IsBanned { get; set; }
    }
}