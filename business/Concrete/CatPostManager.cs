using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class CatPostManager : ICatPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CatPostManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CatPost> Create(CatPost catpost)
        {
            if(string.IsNullOrEmpty(catpost.Title) || string.IsNullOrEmpty(catpost.Content) || catpost.UserId == 0 || catpost.CategoryId == 0)
                return null;
            else
                return await _unitOfWork.catPostRepository.Create(catpost);
        }

        public  async Task<List<CatPost>> GetAllCatPosts()
        {
            return await _unitOfWork.catPostRepository.GetAllCatPosts();
        }

        public async Task<List<CatPost>> GetAllCatPostByCategory(string categoryName,int page,int pageSize)
        {
            if(string.IsNullOrEmpty(categoryName) || page== 0 || pageSize == 0)
                return null;
            else
                return await _unitOfWork.catPostRepository.getCatPostByCategory(categoryName,page,pageSize);
        }

        public async Task<CatPost> GetCatPostsById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.catPostRepository.GetCatPostsById(id);
        }
        public async Task<CatPost> GetCatPostById(string nameUrl,int postId)
        {
            if(string.IsNullOrEmpty(nameUrl) || postId== 0)
                return null;
            else
                return await _unitOfWork.catPostRepository.GetCatPostById(nameUrl,postId);
        }
        public async Task<int> getCatPostCountByCategory(string categoryName)
        {
            if(string.IsNullOrEmpty(categoryName))
                return 0;
            else
                return await  _unitOfWork.catPostRepository.getCatPostCountByCategory(categoryName);
        }
        public async Task<bool> SaveChanges()
        {
            return await _unitOfWork.catPostRepository.SaveChanges();
        }
        public async Task<CatPost> Update(CatPost catpost)
        {
            if(string.IsNullOrEmpty(catpost.Title) || string.IsNullOrEmpty(catpost.Content) || catpost.UserId == 0 || catpost.CategoryId == 0)
                return null;
            else
                return await _unitOfWork.catPostRepository.Update(catpost);
        }

        public async Task<List<CatPost>> GetAll()
        {
            return await _unitOfWork.catPostRepository.GetAll();
        }

        public async Task<CatPost> GetById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.catPostRepository.GetById(id);
        }

        public async Task<CatPost> Delete(CatPost entity)
        {
            if(entity.Id == 0)
                return null;
            else
                return await _unitOfWork.catPostRepository.Delete(entity);
        }

    }
}