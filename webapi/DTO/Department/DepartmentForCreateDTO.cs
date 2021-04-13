using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.Department
{
    public class DepartmentForCreateDTO
    {
        [Required(ErrorMessage = "Bölüm adı alanı boş bırakılamaz...")]
        [StringLength(35,MinimumLength=1,ErrorMessage = "Bölüm adı alanı en az 1 en fazla 35 karakter içerebilir...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bölüm url alanı boş bırakılamaz...")]
        [StringLength(35,MinimumLength=1,ErrorMessage = "Bölüm url alanı en az 1 en fazla 35 karakter içerebilir...")]
        public string NameUrl { get; set; }
    }
}