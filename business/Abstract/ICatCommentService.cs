using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface ICatCommentService : IService<CatComment>
    {
        Task<CatComment> GetCatCommentById(int id);
        Task<List<CatComment>> GetAllCatComments();
        Task<CatComment> GetFavorite(int postId);
    }
}