using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class UniPostLikeManager : IUniPostLikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UniPostLikeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UniPostUserLike> AlreadyLiked(int userId, int postId)
        {
            if(userId == 0 || postId == 0 )
                return null;
            else
                return await _unitOfWork.uniPostLikeRepository.AlreadyLiked(userId,postId);
        }

        public async Task<UniPostUserLike> Like(UniPostUserLike like)
        {
            if(like.UserId == 0 || like.UniPostId == 0)
                return null;
            else
                return await _unitOfWork.uniPostLikeRepository.Create(like);
        }

        public async Task<UniPostUserLike> UnLike(UniPostUserLike like)
        {
            if(like.UserId == 0 || like.UniPostId == 0)
                return null;
            else
               return await _unitOfWork.uniPostLikeRepository.Delete(like);

        }
    }
}