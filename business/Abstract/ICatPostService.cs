using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface ICatPostService : IService<CatPost>
    {
        Task<bool> SaveChanges();
        Task<List<CatPost>> GetAllCatPostByCategory(string categoryName,int page,int pageSize);
        Task<List<CatPost>> GetAllCatPosts();
        Task<CatPost> GetCatPostById(string nameUrl,int postId);
        Task<int> getCatPostCountByCategory(string categoryName);
        Task<CatPost> GetCatPostsById(int id);
    }
}