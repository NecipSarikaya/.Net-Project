using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface IDepartmentService : IService<Department>
    {
        Task<Department> GetDepartmentByUrl(string depNameUrl);
    }
}