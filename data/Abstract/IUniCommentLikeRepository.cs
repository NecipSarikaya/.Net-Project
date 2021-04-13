using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface IUniCommentLikeRepository : IRepository<UniCommentUserLike>
    {
        Task<UniCommentUserLike> AlreadyLiked(int userId, int commentId);
    }
}