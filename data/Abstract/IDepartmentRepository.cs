using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<Department> GetDepartmentByUrl(string depNameUrl);
    }
}