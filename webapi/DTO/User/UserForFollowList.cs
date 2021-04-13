using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.User
{
    public class UserForFollowList
    {
        public int Id { get; set; }

        [StringLength(35,MinimumLength = 3,ErrorMessage = "Ad alanı en az 3 en fazla 35 karakter içerebilir..")]
        public string Name { get; set; }
        
        [StringLength(35,MinimumLength = 2,ErrorMessage = "Soyad alanı en az 2 en fazla 35 karakter içerebilir..")]
        public string LastName { get; set; }
        
        [StringLength(35,MinimumLength = 6,ErrorMessage = "Kullanıcı adı alanı en az 6 en fazla 35 karakter içerebilir..")]
        public string UserName { get; set; }
        [StringLength(120,MinimumLength=1,ErrorMessage = "Kullanıcı profil resmi alanı en az 1 en fazla 120 karakter içerebilir...")]
        public string ImageUrl { get; set; }
        public bool isAlreadyFollowed { get; set; }
    }
}