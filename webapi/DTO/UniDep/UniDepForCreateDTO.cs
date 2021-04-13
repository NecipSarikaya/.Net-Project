using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.UniDep
{
    public class UniDepForCreateDTO
    {
        [Required(ErrorMessage = "Universite seçilmeden işleme devam edilemez..")]
        public int UniversityId { get; set; }
        
        [Required(ErrorMessage = "Bölüm seçilmeden işleme devam edilemez..")]
        public int DepartmentId { get; set; }
    }
}