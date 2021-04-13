using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class CatPostLikeManager : ICatPostLikeService
    {
        private readonly IUnitOfWork  _unitOfWork;
        public CatPostLikeManager(IUnitOfWork  unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CatPostUserLike> AlreadyLiked(int userId, int postId)
        {
            if(userId == 0 ||postId == 0 )
                return null;
            else
                return await _unitOfWork.catPostLikeRepository.AlreadyLiked(userId,postId);
        }

        public async Task<CatPostUserLike> Like(CatPostUserLike like)
        {
            if(like.UserId == 0 || like.CatPostId == 0)
                return null;
            else
                return await _unitOfWork.catPostLikeRepository.Create(like);
        }

        public async Task<CatPostUserLike> UnLike(CatPostUserLike like)
        {
             if(like.UserId == 0 || like.CatPostId == 0)
                return null;
            else
                return await _unitOfWork.catPostLikeRepository.Delete(like);
        }
    }
}