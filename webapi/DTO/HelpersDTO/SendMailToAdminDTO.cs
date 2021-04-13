using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.HelpersDTO
{
    public class SendMailToAdminDTO
    {
        [Required(ErrorMessage="Mail gönderici adı  alanı girilmesi gerekiyor..")]
        [StringLength(35,MinimumLength=3,ErrorMessage="Mail gönderici adı  alanı en az 3 en fazla 35 karakterden oluşabilir..")]
        public string Name { get; set; }

        [Required(ErrorMessage="Mail başlık alanı girilmesi gerekiyor..")]
        [StringLength(100,MinimumLength=1,ErrorMessage="Mail başlık alanı en az 1 en fazla 100 karakterden oluşabilir..")]
        public string Title { get; set; }

        [Required(ErrorMessage="Mail içerik alanı girilmesi gerekiyor..")]
        [StringLength(250,MinimumLength=1,ErrorMessage="Mail içerik alanı en az 1 en fazla 250 karakterden oluşabilir..")]
        public string Content { get; set; }
    }
}