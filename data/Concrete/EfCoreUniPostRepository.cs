using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreUniPostRepository : EfCoreGenericRepository<UniPost>, IUniPostRepository
    {
        private MentorContext _context;
        public EfCoreUniPostRepository(MentorContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UniPost>> GetAllAdmin()
        {
            return await _context.UniPosts
                    .Include(l => l.User)
                    .ToListAsync();
        }

        public async Task<List<UniPost>> GetAllUniPosts()
        {
            return await _context.UniPosts
                        .Include(l => l.User)
                        .Include(l => l.University)
                        .Include(l => l.Department)
                        .ToListAsync();
        }

        public async Task<List<UniPost>> GetAllUniPostsByDepartment(string uniNameUrl, string departmenName, int page, int pageSize)
        {
            return await _context.UniPosts
                    .Include(l => l.University)
                    .Include(l => l.Department)
                    .Include(l => l.UniComments)
                    .ThenInclude( l => l.User)
                    .Include(l => l.User)
                    .Where(l => l.IsVisible == true && l.University.NameUrl == uniNameUrl && l.Department.NameUrl == departmenName)
                    .OrderByDescending(l => l.PublishDate)
                    .Skip((page - 1) * pageSize).Take(pageSize)
                    .ToListAsync();
        }

        public async Task<List<UniPost>> GetAllUniPostsByUniUrl(string uniNameUrl, int page, int pageSize)
        {
            return await _context.UniPosts
                    .Include(l => l.University)
                    .Include(l => l.UniComments)
                    .ThenInclude( l => l.User)
                    .Include(l => l.User)
                    .Where(l => l.IsVisible == true && l.University.NameUrl == uniNameUrl)
                    .OrderByDescending(l => l.PublishDate)
                    .Skip((page - 1) * pageSize).Take(pageSize)
                    .ToListAsync();
        }

        public async Task<int> GetCountByUniDepNameUrl(string uniNameUrl, string depNameUrl)
        {
            var posts = await _context.UniPosts
                    .Include(l => l.University)
                    .Include(l => l.Department)
                    .Where(l => l.Department.NameUrl == depNameUrl && l.University.NameUrl == uniNameUrl)
                    .Where(l => l.IsVisible == true)
                    .ToListAsync();
            return posts.Count;
        }

        public async Task<int> GetCountByUniNameUrl(string uniNameUrl)
        {
            var a = await _context.UniPosts
                    .Include(l => l.University)
                    .Where(l => l.IsVisible == true && l.University.NameUrl == uniNameUrl)
                    .ToListAsync();
            return a.Count;
        }

        public async Task<UniPost> getUniPostById(int id)
        {
            return await _context.UniPosts
                    .Include(l => l.User)
                    .Include(l => l.University)
                    .Include(l => l.Department)
                    .Include(l => l.UniComments)
                    .ThenInclude( l => l.User)
                    .Where(l => l.IsVisible == true)
                    .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}