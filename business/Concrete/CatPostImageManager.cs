using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class CatPostImageManager : ICatPostImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatPostImageManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CatPostImage> Create(CatPostImage entity)
        {
            if(entity.CatPostId == 0 || string.IsNullOrEmpty(entity.ImageUrl))
                return null;
            else
                return await _unitOfWork.catPostImageRepository.Create(entity);
        }
        public async Task<CatPostImage> Delete(CatPostImage entity)
        {
            if(entity.CatPostId == 0)
                return null;
            else
                return await _unitOfWork.catPostImageRepository.Delete(entity);
        }

        public async Task<List<CatPostImage>> GetAll()
        {
            return await _unitOfWork.catPostImageRepository.GetAll();
        }

        public async Task<CatPostImage> GetById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.catPostImageRepository.GetById(id);
        }

        public async Task<bool> GetImageByPostId(int postId)
        {
            if(postId == 0)
                return false;
            else
                return await _unitOfWork.catPostImageRepository.GetImageByPostId(postId);
        }

        public async Task<List<string>> GetImages(int postId)
        {
            if(postId == 0)
                return null;
            else
                return await _unitOfWork.catPostImageRepository.GetImages(postId);
        }

        public async Task<CatPostImage> Update(CatPostImage entity)
        {
            if(entity.CatPostId == 0 || string.IsNullOrEmpty(entity.ImageUrl))
                return null;
            else
                return await _unitOfWork.catPostImageRepository.Update(entity);
        }
    }
}