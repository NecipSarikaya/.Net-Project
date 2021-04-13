using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.User
{
    public class UserForProfileDTO
    {
        public int Id { get; set; }

        [StringLength(35,MinimumLength = 3,ErrorMessage = "Ad alanı en az 3 en fazla 35 karakter içerebilir..")]
        public string Name { get; set; }

        public bool IsCurrentUser { get; set; }

        [StringLength(35,MinimumLength = 2,ErrorMessage = "Soyad alanı en az 2 en fazla 35 karakter içerebilir..")]
        public string LastName { get; set; }

        [StringLength(35,MinimumLength = 1,ErrorMessage = "Cinsiyet alanı en az 1 en fazla 35 karakter içerebilir..")]
        public string Gender { get; set; }

        [StringLength(35,MinimumLength = 6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 35 karakter içerebilir..")]
        public string UserName { get; set; }
        public int Point { get; set; }
        public string About { get; set; }
        [StringLength(120,MinimumLength=1,ErrorMessage = "İnstagram link alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string InstagramLink { get; set; }

        [StringLength(120,MinimumLength=1,ErrorMessage = "Twitter link alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string TwitterLink { get; set; }
        public bool IsAlreadyFollowed { get; set; }

        [StringLength(35,MinimumLength=1,ErrorMessage = "Üniversite alanı en az 1 en fazla 35 karakter içerebilir...")]
        public string UniversityName { get; set; }
        [StringLength(35,MinimumLength=1,ErrorMessage = "Bölüm alanı en az 1 en fazla 35 karakter içerebilir...")]
        public string DepartmentName { get; set; }

        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı profil resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string ImageUrl { get; set; }
        
        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı rozet resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string BadgeUrl { get; set; }
        public List<UserForGuestFollowList> Followers { get; set; }
        public List<UserForGuestFollowList> Followings { get; set; }
    }
}