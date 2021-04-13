using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface ICatCommentLikeRepository:IRepository<CatCommentUserLike>
    {
        Task<CatCommentUserLike> AlreadyLiked(int userId,int postId);
    }
}