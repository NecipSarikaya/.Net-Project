using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface IUniDepRepository : IRepository<UniversityDepartment>
    {
        Task<UniversityDepartment> GetDepById(int uniId, int depId);
        Task<List<UniversityDepartment>> GetAllDepByUni(string uniNameUrl);
    }
}