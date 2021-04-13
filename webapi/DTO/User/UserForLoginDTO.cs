using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.User
{
    public class UserForLoginDTO
    {
        [Required(ErrorMessage ="Kullanıcı adı veya Email alanı bilgisi girilmesi gerekmektedir..")]
        [StringLength(40,MinimumLength = 6,ErrorMessage = "Kullanıcı adı veya Email alanı en az 11 en fazla 40 karakter içerebilir..")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı bilgisi girilmesi gerekmektedir..")]
        [StringLength(25,MinimumLength = 6,ErrorMessage = "Şifre alanı en az 6 en fazla 25 karakter içerebilir..")]
        [DataType(DataType.Password,ErrorMessage = "Girilen şifre formata uygun değil..")]
        public string Password { get; set; }
    }
}