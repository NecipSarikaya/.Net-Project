using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.User
{
    public class UserForReset
    {
        [StringLength(40,MinimumLength = 11,ErrorMessage = "Email alanı en az 11 en fazla 40 karakter içerebilir..")]
        [EmailAddress(ErrorMessage= "Email alanına girilen veri formata uygun değil..")]
        public string Email { get; set; }
        public string Token { get; set; }
        
        [StringLength(25,MinimumLength = 6,ErrorMessage = "Şifre alanı en az 6 en fazla 25 karakter içerebilir..")]
        [DataType(DataType.Password,ErrorMessage = "Şifre alanına girilen veri formata uygun değil..")]
        public string Password { get; set; }
    }
}