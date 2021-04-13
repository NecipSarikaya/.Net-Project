using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> Create(Category entity)
        {
            if(string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.NameUrl) || string.IsNullOrEmpty(entity.Description) || string.IsNullOrEmpty(entity.ImageUrl))
                return null;
            else
                return await _unitOfWork.categoryRepository.Create(entity);
        }

        public async Task<Category> Delete(Category entity)
        {
            if(entity.Id == 0)
                return null;
            else
                return await _unitOfWork.categoryRepository.Delete(entity);
        }

        public async Task<List<Category>> GetAll()
        {
            return await _unitOfWork.categoryRepository.GetAll();
        }

        public async Task<Category> GetById(int id)
        {
            if(id == 0)
                return null;
            else
               return await _unitOfWork.categoryRepository.GetById(id);
        }

        public async Task<Category> GetCategoryByNameUrl(string nameUrl)
        {
            if(string.IsNullOrEmpty(nameUrl))
                return null;
            else
                return await  _unitOfWork.categoryRepository.GetCategoryByNameUrl(nameUrl);
        }

        public async Task<Category> Update(Category entity)
        {
            if(string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.NameUrl) || string.IsNullOrEmpty(entity.Description) || string.IsNullOrEmpty(entity.ImageUrl))
                return null;
            else
                return await _unitOfWork.categoryRepository.Update(entity);
        }
    }
}