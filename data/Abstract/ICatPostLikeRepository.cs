using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface ICatPostLikeRepository : IRepository<CatPostUserLike>
    {
        Task<CatPostUserLike> AlreadyLiked(int userId,int postId);
    }
}