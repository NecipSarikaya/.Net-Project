using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class CatCommentManager : ICatCommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatCommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CatComment> Create(CatComment comment)
        {
            if(string.IsNullOrEmpty(comment.CommentContent) || comment.UserId == 0 || comment.CatPostId == 0)
                return null;
            else
                return await _unitOfWork.catCommentRepository.Create(comment);
        }

        public async Task<CatComment> Delete(CatComment entity)
        {
            if(entity.Id == 0)
                return null;
            else
                return await _unitOfWork.catCommentRepository.Delete(entity);
        }

        public async Task<List<CatComment>> GetAll()
        {
            return await _unitOfWork.catCommentRepository.GetAll();
        }

        public async Task<List<CatComment>> GetAllCatComments()
        {
            return await _unitOfWork.catCommentRepository.GetAllCatComments();
        }

        public async Task<CatComment> GetById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.catCommentRepository.GetById(id);
        }

        public async Task<CatComment> GetCatCommentById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.catCommentRepository.GetCatCommentById(id);
        }

        public async Task<CatComment> GetFavorite(int postId)
        {
            if(postId == 0)
                return null;
            else
                return await _unitOfWork.catCommentRepository.GetFavorite(postId);
        }

        public async Task<CatComment> Update(CatComment comment)
        {
            if(string.IsNullOrEmpty(comment.CommentContent) || comment.UserId == 0 || comment.CatPostId == 0)
                return null;
            else
                return await _unitOfWork.catCommentRepository.Update(comment);
        }
    }
}