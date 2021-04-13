using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.User
{
    public class UserForGuestProfile
    {
        public bool IsCurrentUser { get; set; }
        public int Id { get; set; }
        
        [StringLength(35,MinimumLength = 3,ErrorMessage = "Ad alanı en az 3 en fazla 35 karakter içerebilir..")]
        public string Name { get; set; }
        
        [StringLength(35,MinimumLength = 2,ErrorMessage = "Soyad alanı en az 2 en fazla 35 karakter içerebilir..")]
        public string LastName { get; set; }

        [StringLength(35,MinimumLength = 6,ErrorMessage = "Cinsiyet adı alanı en az 1 en fazla 35 karakter içerebilir..")]
        public string Gender { get; set; }

        [StringLength(35,MinimumLength = 6,ErrorMessage = "Kullancı adı alanı en az 6 en fazla 35 karakter içerebilir..")]
        public string UserName { get; set; }
        public int UniversityId { get; set; }
        public int DepartmentId { get; set; }
        public string About { get; set; }

        [StringLength(120,MinimumLength=1,ErrorMessage = "İnstagram link alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string InstagramLink { get; set; }
        [StringLength(120,MinimumLength=1,ErrorMessage = "Twitter link alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string TwitterLink { get; set; }

        [EmailAddress(ErrorMessage = "Girilen bilgi email formatında değil..")]
        [StringLength(40,MinimumLength = 11,ErrorMessage = "Email alanı en az 11 en fazla 40 karakter içerebilir..")]
        public string Email { get; set; }
        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı profil resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string ImageUrl { get; set; }
        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı rozet resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string BadgeUrl { get; set; }
        public int Point { get; set; }
        public List<UserForFollowList> Followers { get; set; }
        public List<UserForFollowList> Followings { get; set; }
    }
}