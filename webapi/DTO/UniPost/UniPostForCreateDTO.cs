using System;
using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.UniPost
{
    public class UniPostForCreateDTO
    {
        [StringLength(100,MinimumLength = 1,ErrorMessage = "Gönderi başlık alanı en az 1 en fazla 50 karakter içermelidir..")]
        [Required(ErrorMessage = "Gönderi başlık alanı boş bırakılamaz..")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Gönderi içerik alanı boş bırakılamaz..")]
        [StringLength(250,MinimumLength = 1,ErrorMessage = "Gönderi içerik alanı en az 1 en fazla 150 karakter içermelidir..")]
        public string Content  { get; set; }
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Universite seçilmeden gönderi paylaşılamaz..")]
        public int UniversityId { get; set; }
        [Required(ErrorMessage = "Bölüm seçilmeden gönderi paylaşılamaz..")]
        public int DepartmentId { get; set; }
    }
}