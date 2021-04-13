using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface IUniCommentRepository : IRepository<UniComment>
    {
        Task<UniComment> GetUniCommentById(int id);
        Task<List<UniComment>> GetAllUniComments();
        Task<UniComment> GetFavorite(int postId);
        Task<List<UniComment>> GetUniCommentsByPostId(int postId);
    }
}