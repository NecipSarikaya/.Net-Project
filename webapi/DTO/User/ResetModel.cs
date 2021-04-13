using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.User
{
    public class ResetModel
    {
        [StringLength(40,MinimumLength = 11,ErrorMessage = "Email alanı en az 11 en fazla 25 karakter içerebilir..")]
        [EmailAddress(ErrorMessage="Email alanına girilen veri formata uygun değil..")] 
        public string ResetEmail { get; set; }
    }
}