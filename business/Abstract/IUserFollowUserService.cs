using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface IUserFollowUserService : IService<UserFollowUser>
    {
        Task<bool> IsAlreadyFollowed(int followerUserId,int userId);
        Task<List<User>> GetFollowers(int userId);
        Task<List<User>> GetFollowings(int userId);
        Task<IEnumerable<int>> GetFollows(int userId,bool isFollowers);
    }
}