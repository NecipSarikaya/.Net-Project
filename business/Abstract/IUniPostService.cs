using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface IUniPostService : IService<UniPost>
    {
       Task<List<UniPost>> GetAllUniPostsByDepartment(string uniNameUrl, string departmenName,int page,int pageSize); 
       Task<List<UniPost>> GetAllUniPostsByUniUrl(string uniNameUrl,int page,int pageSize);
       Task<UniPost> GetUniPostById(int id);
       Task<List<UniPost>> GetAllAdmin();
       Task<List<UniPost>> GetAllUniPosts();
       Task<int> GetCountByUniNameUrl(string uniNameUrl);
       Task<int> GetCountByUniDepNameUrl(string uniNameUrl,string depNameUrl);
    }
}