using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class CatCommentLikeManager : ICatCommentLikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatCommentLikeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CatCommentUserLike> AlreadyLiked(int userId, int postId)
        {
            if(userId == 0 || postId == 0)
                return null;
            else
                return await _unitOfWork.catCommentLikeRepository.AlreadyLiked(userId,postId);
        }

        public async Task<CatCommentUserLike> Like(CatCommentUserLike like)
        {
            if(like.UserId == 0 ||like.CatCommentId == 0)
                return null;
            else
                return await _unitOfWork.catCommentLikeRepository.Create(like);
        }

        public async Task<CatCommentUserLike> UnLike(CatCommentUserLike like)
        {
            if(like.UserId == 0 ||like.CatCommentId == 0)
                return null;
            else
                return await _unitOfWork.catCommentLikeRepository.Delete(like);
        }
    }
}