using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface IUniversityRepository : IRepository<University>
    {
        Task<bool> HasADepartment(int uniId,int depId);
        Task<University> GetUniByUniNameUrl(string uniNameUrl);
        Task<List<University>> GetAllByOrdered();
    }
}