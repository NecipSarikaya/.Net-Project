using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.University
{
    public class UniversityForCreateDTO
    {
        [Required(ErrorMessage="Ünivesite adı alanı giilmesi gerekiyor..")]
        [StringLength(35,MinimumLength = 1,ErrorMessage="Üniversite adı alanı en az 1 en falza 35 karakter içerebilir..")]
        public string Name { get; set; }
        [Required(ErrorMessage="Ünivesite url alanı giilmesi gerekiyor..")]
        [StringLength(35,MinimumLength = 1,ErrorMessage="Üniversite url alanı en az 1 en falza 35 karakter içerebilir..")]
        public string NameUrl { get; set; }
    }
}