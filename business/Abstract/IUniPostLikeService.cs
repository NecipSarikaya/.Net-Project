using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface IUniPostLikeService
    {
        Task<UniPostUserLike> AlreadyLiked(int userId,int postId);
        Task<UniPostUserLike> Like(UniPostUserLike like);
        Task<UniPostUserLike> UnLike(UniPostUserLike like);
    }
}