using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface IUniDepService : IService<UniversityDepartment>
    {
        Task<List<UniversityDepartment>> GetAllDepByUni(string uniNameUrl);
        Task<UniversityDepartment> GetDepById(int uniId,int depId);
    }
}