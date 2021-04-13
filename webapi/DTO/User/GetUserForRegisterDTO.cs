using System.Collections.Generic;

namespace webapi.DTO.User
{
    public class GetUserForRegisterDTO
    {
        public List<entity.University> Universities { get; set; }
        public List<entity.Department> Departments { get; set; }
    }
}