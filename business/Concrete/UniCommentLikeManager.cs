using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class UniCommentLikeManager : IUniCommentLikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UniCommentLikeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UniCommentUserLike> AlreadyLiked(int userId, int commentId)
        {
            if(userId == 0 ||commentId == 0)
                return null;
            else
                return await _unitOfWork.uniCommentLikeRepository.AlreadyLiked(userId,commentId);
        }

        public async Task<UniCommentUserLike> Like(UniCommentUserLike like)
        {
            if(like.UserId == 0 ||like.UniCommentId == 0)
                return null;
            else
                return await _unitOfWork.uniCommentLikeRepository.Create(like);
        }

        public async Task<UniCommentUserLike> UnLike(UniCommentUserLike like)
        {
            if(like.UserId == 0 ||like.UniCommentId == 0)
                return null;
            else
                return await _unitOfWork.uniCommentLikeRepository.Delete(like);
        }
    }
}