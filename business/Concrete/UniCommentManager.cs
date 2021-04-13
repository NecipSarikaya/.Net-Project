using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class UniCommentManager : IUniCommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UniCommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UniComment> Create(UniComment comment)
        {
            if(comment.UserId == 0 || comment.UniPostId == 0 || string.IsNullOrEmpty(comment.CommentContent) || comment.CommentDate == null)
                return null;
            else
                return await _unitOfWork.uniCommentRepository.Create(comment);
        }

        public async Task<UniComment> Delete(UniComment entity)
        {
            if(entity.Id == 0)
                return null;
            else
                return await _unitOfWork.uniCommentRepository.Delete(entity);
        }

        public async Task<List<UniComment>> GetAll()
        {
            return await _unitOfWork.uniCommentRepository.GetAll();
        }

        public async Task<List<UniComment>> GetAllUniComments()
        {
            return await _unitOfWork.uniCommentRepository.GetAllUniComments();
        }

        public async Task<UniComment> GetById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.uniCommentRepository.GetById(id);
        }

        public async Task<UniComment> GetUniCommentById(int id)
        {   
            if(id == 0)
                return null;
            else
                return await _unitOfWork.uniCommentRepository.GetUniCommentById(id);
        }

        public async Task<UniComment> GetFavorite(int postId)
        {
            if(postId == 0)
                return null;
            else
                return await _unitOfWork.uniCommentRepository.GetFavorite(postId);
        }

        public async Task<UniComment> Update(UniComment comment)
        {
            if(string.IsNullOrEmpty(comment.CommentContent) || comment.Id == 0 || comment.UserId == 0 || comment.UniPostId == 0 )
                return null;
            else
                return await _unitOfWork.uniCommentRepository.Update(comment);
        }

        public async Task<List<UniComment>> GetUniCommentsByPostId(int postId)
        {
            if(postId == 0)
                return null;
            else
                return await _unitOfWork.uniCommentRepository.GetUniCommentsByPostId(postId);
        }
    }
}