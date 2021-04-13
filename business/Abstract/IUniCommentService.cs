using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface IUniCommentService : IService<UniComment>
    {
        Task<UniComment> GetUniCommentById(int id);
        Task<UniComment> GetFavorite(int postId);
        Task<List<UniComment>> GetAllUniComments();
        Task<List<UniComment>> GetUniCommentsByPostId(int postId);
    }
}