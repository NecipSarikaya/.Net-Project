using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface IUniCommentLikeService
    {
        Task<UniCommentUserLike> Like(UniCommentUserLike like);
        Task<UniCommentUserLike> UnLike(UniCommentUserLike like);
        Task<UniCommentUserLike> AlreadyLiked(int userId,int commentId);
    }
}