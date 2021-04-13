using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.User
{
    public class UserForFollowDTO
    {
        [Required(ErrorMessage="Takip edilecek kullanıcı seçilmedi..")]
        public int FollowerUserId { get; set; }

        [Required(ErrorMessage="Takip edecek kullanıcı seçilmedi..")]
        public int UserId { get; set; }
    }
}