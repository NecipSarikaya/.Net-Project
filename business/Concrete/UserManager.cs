using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<User> Create(User entity)
        {
            if(string.IsNullOrEmpty(entity.UserName) || string.IsNullOrEmpty(entity.Email) || entity.UniversityId == 0 || entity.DepartmentId == 0)
                return null;
            else
                return await _unitOfWork.userRepository.Create(entity);
        }

        public async Task<User> Delete(User entity)
        {
            if(entity.Id == 0)
                return null;
            else
                return await _unitOfWork.userRepository.Delete(entity);
        }

        public async Task<List<User>> GetAll()
        {
            return await _unitOfWork.userRepository.GetAll();
        }

        public async Task<User> GetById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.userRepository.GetById(id);
        }

        public async Task<List<CatPost>> GetPublishedCatPosts(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.userRepository.GetPublishedCatPosts(id);
        }

        public async Task<int> GetPublishedCatPostsCount(int id)
        {
            if(id == 0)
                return 0;
            else
                return await _unitOfWork.userRepository.GetPublishedCatPostsCount(id);
        }

        public async Task<List<UniPost>> GetPublishedPosts(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.userRepository.GetPublishedPosts(id);
        }

        public async Task<int> GetPublishedPostsCount(int id)
        {
            if(id == 0)
                return 0;
            else
                return await _unitOfWork.userRepository.GetPublishedPostsCount(id);
        }

        public async Task<User> GetUpdateUser(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.userRepository.GetUpdateUser(id);
        }

        public async Task<User> Update(User entity)
        {
            if(entity.Id == 0)
                return null;
            else
                return await _unitOfWork.userRepository.Update(entity);
        }
    }
}