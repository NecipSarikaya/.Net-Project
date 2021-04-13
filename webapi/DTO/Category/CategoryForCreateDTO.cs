using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.Category
{
    public class CategoryForCreateDTO
    {
        [Required(ErrorMessage = "Kategori adı alanı boş bırakılamaz...")]
        [StringLength(35,MinimumLength=1,ErrorMessage="Kategori adı alanı en az 1 en fazla 35 karakter içerebilir..")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Kategori url alanı boş bırakılamaz...")]
        [StringLength(35,MinimumLength=1,ErrorMessage="Kategori url alanı en az 1 en fazla 35 karakter içerebilir..")]
        public string NameUrl { get; set; }
        
        [Required(ErrorMessage = "Kategori açıklama alanı boş bırakılamaz...")]
        [StringLength(200,MinimumLength=1,ErrorMessage="Kategori Açıklama alanı en az 1 en fazla 200 karakter içerebilir..")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Kategori resim url alanı boş bırakılamaz...")]
        [StringLength(120,MinimumLength=1,ErrorMessage="Kategori resim url alanı en az 1 en fazla 120 karakter içerebilir..")]
        public string ImageUrl { get; set; }
    }
}