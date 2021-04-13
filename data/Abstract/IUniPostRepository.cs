using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface IUniPostRepository : IRepository<UniPost>
    {
        Task<List<UniPost>> GetAllUniPosts();
        Task<List<UniPost>> GetAllUniPostsByDepartment(string uniNameUrl, string departmenName,int page,int pageSize);
        Task<List<UniPost>> GetAllUniPostsByUniUrl(string uniNameUrl,int page,int pageSize);
        Task<UniPost> getUniPostById(int id);
        Task<int> GetCountByUniNameUrl(string uniNameUrl);
        Task<int> GetCountByUniDepNameUrl(string uniNameUrl,string depNameUrl);
        Task<List<UniPost>> GetAllAdmin();
    }
}