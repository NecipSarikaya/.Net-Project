using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class UserFollowUserManager : IUserFollowUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserFollowUserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UserFollowUser> Create(UserFollowUser entity)
        {
            if(entity.FollowerId == 0 || entity.UserId == 0)
                return null;
            else
                return await _unitOfWork.userFollowUserRepository.Create(entity);
        }

        public async Task<UserFollowUser> Delete(UserFollowUser entity)
        {
            if(entity.FollowerId == 0 || entity.UserId == 0)
                return null;
            else
                return await _unitOfWork.userFollowUserRepository.Delete(entity);
        }

        public async Task<List<UserFollowUser>> GetAll()
        {
            return await _unitOfWork.userFollowUserRepository.GetAll();
        }

        public async Task<UserFollowUser> GetById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.userFollowUserRepository.GetById(id);
        }

        public async Task<List<User>> GetFollowers(int userId)
        {
            if(userId == 0)
                return null;
            else
                return await _unitOfWork.userFollowUserRepository.GetFollowers(userId);
        }

        public async Task<List<User>> GetFollowings(int userId)
        {
            if(userId == 0)
                return null;
            else
                return await _unitOfWork.userFollowUserRepository.GetFollowings(userId);
        }

        public async Task<IEnumerable<int>> GetFollows(int userId,bool isFollowers)
        {
            if(userId == 0)
                return null;
            else
                return await _unitOfWork.userFollowUserRepository.GetFollows(userId,isFollowers);
        }

        public async Task<bool> IsAlreadyFollowed(int followerUserId, int userId)
        {
            if(followerUserId == 0|| userId == 0)
                return false;
            else
                return await _unitOfWork.userFollowUserRepository.IsAlreadyFollowed(followerUserId,userId);
        }

        public async Task<UserFollowUser> Update(UserFollowUser entity)
        {
            if(entity.FollowerId == 0 || entity.UserId == 0)
                return null;
            else
                return await _unitOfWork.userFollowUserRepository.Update(entity);
        }
    }
}