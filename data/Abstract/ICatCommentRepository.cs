using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface ICatCommentRepository : IRepository<CatComment>
    {
        Task<CatComment> GetCatCommentById(int id);
        Task<List<CatComment>> GetAllCatComments();
        Task<CatComment> GetFavorite(int postId);
    }
}