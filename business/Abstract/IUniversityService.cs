using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface IUniversityService : IService<University>
    {
        Task<University> GetUniByUniNameUrl(string uniNameUrl);
        Task<bool> HasADepartment(int uniId,int depId);
        Task<List<University>> GetAllByOrdered();
    }
}