using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUpdateUser(int id);
        Task<List<UniPost>> GetPublishedPosts(int id);
        Task<List<CatPost>> GetPublishedCatPosts(int id);
        Task<int> GetPublishedPostsCount(int id);
        Task<int> GetPublishedCatPostsCount(int id);
    }
}