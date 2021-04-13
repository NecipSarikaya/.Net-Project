using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface ICatPostRepository:IRepository<CatPost>
    {
        Task<List<CatPost>> GetAllCatPosts();
        Task<CatPost> GetCatPostById(string nameUrl,int postId);
        Task<List<CatPost>> getCatPostByCategory(string categoryName,int page,int pageSize);
        Task<int> getCatPostCountByCategory(string categoryName);
        Task<CatPost> GetCatPostsById(int id);
    }
}