using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface IUniPostLikeRepository:IRepository<UniPostUserLike>
    {
        Task<UniPostUserLike> AlreadyLiked(int userId,int postId);
    }
}