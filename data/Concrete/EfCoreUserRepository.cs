using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreUserRepository : EfCoreGenericRepository<User>,IUserRepository
    {
        private MentorContext _context;
        public EfCoreUserRepository(MentorContext context) :base(context)
        {
            _context = context;
        }

        public async Task<List<UniPost>> GetPublishedPosts(int id)
        {
            return await _context.UniPosts
                .Include(l => l.University)
                .Where(l => l.UserId == id && l.IsVisible == true)
                .OrderByDescending(l => l.PublishDate)
                .ToListAsync();
        }
        public async Task<List<CatPost>> GetPublishedCatPosts(int id)
        {
            return await _context.CatPosts
                .Include(l=>l.Category)
                .Where(l => l.UserId == id && l.IsVisible == true)
                .OrderByDescending(l => l.PublishDate)
                .ToListAsync();
        }
        public async Task<User> GetUpdateUser(int id)
        {
            return await _context.Users
                    .Include(l => l.University)
                    .Include(l => l.Department)
                    .FirstOrDefaultAsync( l=> l.Id == id);
        }

        public async Task<int> GetPublishedPostsCount(int id)
        {
            var posts =  await _context.UniPosts
                .Where(l => l.UserId == id && l.IsVisible == true)
                .ToListAsync();
            return posts.Count;
        }

        public async Task<int> GetPublishedCatPostsCount(int id)
        {
            var posts =  await _context.CatPosts
                .Where(l => l.UserId == id && l.IsVisible == true)
                .ToListAsync();
            return posts.Count;
        }
    }
}