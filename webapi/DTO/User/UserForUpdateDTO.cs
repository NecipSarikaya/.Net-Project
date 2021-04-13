using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.User
{
    public class UserForUpdateDTO
    {
        public int Id { get; set; }

        [StringLength(35,MinimumLength = 3,ErrorMessage="Ad alanı en az 3 en fazla 35 karakter içerebilir..")]
        public string Name { get; set; }

        [StringLength(35,MinimumLength = 2,ErrorMessage="Soyadı alanı en az 3 en fazla 35 karakter içerebilir..")]
        public string LastName { get; set; }

        [StringLength(35,MinimumLength=1,ErrorMessage = "Cinsiyet alanı en az 1 en fazla 35 karakter içerebilir...")]
        public string Gender { get; set; }

        [StringLength(35,MinimumLength = 6,ErrorMessage="Kullanıcı adı  alanı en az 6 en fazla 35 karakter içerebilir..")]
        public string UserName { get; set; }
        public string About { get; set; }

        [StringLength(120,MinimumLength=1,ErrorMessage = "İnstagram link alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string InstagramLink { get; set; }
        
        [StringLength(120,MinimumLength=1,ErrorMessage = "Twitter link alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string TwitterLink { get; set; }
        public int UniversityId { get; set; }
        public int DepartmentId { get; set; }

        [StringLength(40,MinimumLength = 11,ErrorMessage="Email alanı en az 11 en fazla 40 karakter içerebilir..")]
        [EmailAddress(ErrorMessage = "Email alanında girilen veri formata uygun değil..")]
        public string Email { get; set; }
 
        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı profil resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string ImageUrl { get; set; }
        public bool IsEmailChanged { get; set; }
    }
}