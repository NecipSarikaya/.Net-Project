using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface ICatCommentLikeService
    {
        Task<CatCommentUserLike> Like(CatCommentUserLike like);
        Task<CatCommentUserLike> UnLike(CatCommentUserLike like);
        Task<CatCommentUserLike> AlreadyLiked(int userId,int postId);
    }
}