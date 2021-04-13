using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreCatPostRepository : EfCoreGenericRepository<CatPost>, ICatPostRepository
    {
        private MentorContext _context;
        public EfCoreCatPostRepository(MentorContext context) :base(context)
        {
            _context = context;
        }
        public async Task<List<CatPost>> GetAllCatPosts()
        {
            return await _context.CatPosts
                .Include(l => l.User)
                .Include(l=>l.Category)
                .ToListAsync();
        }
        public async Task<List<CatPost>> getCatPostByCategory(string categoryName,int page,int pageSize)
        {
            return await _context.CatPosts
                    .Include(l => l.Category)
                    .Include( l => l.CatComments)
                    .ThenInclude( l => l.User)
                    .Include( l => l.User)
                    .Where(l => l.Category.NameUrl == categoryName && l.IsVisible == true )
                    .OrderByDescending(l => l.PublishDate)
                    .Skip((page-1)*pageSize).Take(pageSize)
                    .ToListAsync();
        }

        public async Task<CatPost> GetCatPostById(string nameUrl,int postId)
        {
                return await _context.CatPosts
                        .Include(c => c.CatComments)
                        .ThenInclude( l => l.User)
                        .Include(c => c.Category)
                        .Include(c => c.User)
                        .FirstOrDefaultAsync(l => l.Category.NameUrl == nameUrl && l.Id == postId);
        }

        public async Task<int> getCatPostCountByCategory(string categoryName)
        {
                var a = await _context.CatPosts
                        .Include(l => l.Category)
                        .Where(l => l.Category.NameUrl == categoryName)
                        .Where(l => l.IsVisible == true)
                        .ToListAsync();
                return a.Count;
        }

        public async Task<CatPost> GetCatPostsById(int id)
        {
            return await _context.CatPosts
                    .Include(l => l.User)
                    .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}