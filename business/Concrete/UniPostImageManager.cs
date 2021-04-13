using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class UniPostImageManager : IUniPostImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UniPostImageManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UniPostImage> Create(UniPostImage entity)
        {
            if(entity.UniPostId == 0 || string.IsNullOrEmpty(entity.ImageUrl))
                return null;
            else
                return await _unitOfWork.uniPostImageRepository.Create(entity);
        }

        public async Task<UniPostImage> Delete(UniPostImage entity)
        {
            if(entity.UniPostId == 0)
                return null;
            else
                return await _unitOfWork.uniPostImageRepository.Delete(entity);
        }

        public async Task<List<UniPostImage>> GetAll()
        {
            return await _unitOfWork.uniPostImageRepository.GetAll();
        }
        public async Task<UniPostImage> GetById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.uniPostImageRepository.GetById(id);
        }

        public async Task<UniPostImage> Update(UniPostImage entity)
        {
            if(entity.UniPostId == 0 ||string.IsNullOrEmpty(entity.ImageUrl))
                return null;
            else
                return await _unitOfWork.uniPostImageRepository.Update(entity);
        }

        public async Task<bool> HasImage(int postId)
        {
            if(postId == 0 )
                return false;
            else
                return await _unitOfWork.uniPostImageRepository.HasImage(postId);
        }

        public async Task<List<string>> GetImages(int postId)
        {
            if(postId == 0)
                return null;
            else
                return await _unitOfWork.uniPostImageRepository.GetImages(postId);
        }
    }
}