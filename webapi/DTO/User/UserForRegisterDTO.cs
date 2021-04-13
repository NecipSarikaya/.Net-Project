using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.User
{
    public class UserForRegisterDTO
    {
        [Required(ErrorMessage="İsim alanı boş bırakılamaz")]
        [StringLength(35,MinimumLength = 3,ErrorMessage = "Ad alanı en az 3 en fazla 35 karakter içerebilir..")]
        public string Name { get; set; }

        [Required(ErrorMessage="Soyad alanı boş bırakılamaz")]
        [StringLength(35,MinimumLength = 2,ErrorMessage = "Soyad alanı en az 2 en fazla 35 karakter içerebilir..")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Email alanı boş bırakılamaz")]
        [StringLength(40,MinimumLength = 11,ErrorMessage = "Email alanı en az 11 en fazla 40 karakter içerebilir..")]
        [EmailAddress(ErrorMessage = "Girilen Email bilgisi formata uygun değil")]
        public string Email { get; set; }

        [Required(ErrorMessage="Kullanıcı adı alanı boş bırakılamaz")]
        [StringLength(35,MinimumLength = 6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 35 karakter içerebilir..")]
        public string UserName { get; set; }

        [Required(ErrorMessage="Cinsiyet alanı boş bırakılamaz")]        
        [StringLength(35,MinimumLength = 1,ErrorMessage = "Cinsiyet alanı en az 1 en fazla 35 karakter içerebilir..")]
        public string Gender { get; set; }

        [Required(ErrorMessage="Universite alanı boş bırakılamaz")]
        public int UniversityId { get; set; }

        [Required(ErrorMessage="Bölüm alanı boş bırakılamaz")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage="Şifre alanı boş bırakılamaz")]
        [StringLength(25,MinimumLength = 6,ErrorMessage = "Şifre alanı en az 6 en fazla 25 karakter içerebilir..")]
        [DataType(DataType.Password,ErrorMessage = "Şifre alanı formata uygun değil..")]
        public string Password { get; set; }
        public string ImageUrl { get; set; }
    }
}