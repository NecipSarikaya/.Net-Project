using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface ICatPostLikeService
    {
        Task<CatPostUserLike> Like(CatPostUserLike like);
        Task<CatPostUserLike> UnLike(CatPostUserLike like);
        Task<CatPostUserLike> AlreadyLiked(int userId,int postId);
    }
}