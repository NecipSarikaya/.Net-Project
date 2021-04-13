using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreUserFollowUserRepository: EfCoreGenericRepository<UserFollowUser>, IUserFollowUserRepository
    {
        private MentorContext _context;
        public EfCoreUserFollowUserRepository(MentorContext context) :base(context)
        {
            _context = context;
        }

        public async Task<bool> IsAlreadyFollowed(int followerUserId, int userId)
        {
            return await _context.UserFollowUser
                .AnyAsync(l => l.UserId== userId && l.FollowerId == followerUserId);
        }

        public async Task<List<User>> GetFollowings(int userId)
        {
            var users = _context.Users
                        .Where( l => l.Id != userId)
                        .AsQueryable();
            var result = await GetFollows(userId,true);
            return await users.Where( u => result.Contains(u.Id)).ToListAsync();
        }
        public async Task<List<User>> GetFollowers(int userId)
        {
            var users = _context.Users
                        .Where( l => l.Id != userId)
                        .AsQueryable();
            var result = await GetFollows(userId,false);
            return await users.Where( u => result.Contains(u.Id)).ToListAsync();
        }
        public async Task<IEnumerable<int>> GetFollows(int userId,bool isFollowers)
        {
            var user = await _context.Users
                    .Include( l => l.Followers)
                    .Include( l => l.Followings)
                    .FirstOrDefaultAsync( l => l.Id == userId);
            if(isFollowers)
            {
                return user.Followers
                            .Where(l => l.FollowerId == userId)
                            .Select( l => l.UserId);
            }else
            {
                return user.Followings
                            .Where(l => l.UserId == userId)
                            .Select( l => l.FollowerId);
            }
        }
    }
}