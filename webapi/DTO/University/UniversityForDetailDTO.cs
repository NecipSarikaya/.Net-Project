using System.Collections.Generic;
using webapi.DTO.HelpersDTO;

namespace webapi.DTO.University
{
    public class UniversityForDetailDTO
    {
        public List<UniCatDepListDTO> Have  { get; set; }
        public List<UniCatDepListDTO> NotHave  { get; set; }
    }
}