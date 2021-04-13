using System.ComponentModel.DataAnnotations;

namespace webapi.DTO.HelpersDTO
{
    public class UniCatDepListDTO
    {
        public int Id { get; set; }
        
        [StringLength(35,MinimumLength=1,ErrorMessage = "Üniversite/Bölüm ad alanı en az 1 en fazla 35 karakter içerebilir...")]
        public string Name { get; set; }

        [StringLength(35,MinimumLength=1,ErrorMessage = "Üniversite/Bölüm url alanı en az 1 en fazla 35 karakter içerebilir...")]
        public string NameUrl { get; set; }
    }
}