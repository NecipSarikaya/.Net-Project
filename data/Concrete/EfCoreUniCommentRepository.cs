using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreUniCommentRepository : EfCoreGenericRepository<UniComment>, IUniCommentRepository
    {
        private MentorContext _context;
        public EfCoreUniCommentRepository(MentorContext context) :base(context)
        {
            _context = context;
        }

        public async Task<List<UniComment>> GetAllUniComments()
        {
            return await _context.UniComments
                .Include(l => l.User)
                .ToListAsync();
        }

        public async Task<UniComment> GetUniCommentById(int id)
        {
            return await _context.UniComments
                .Include(l => l.User)
                .FirstOrDefaultAsync( l => l.Id == id);
        }

        public async Task<UniComment> GetFavorite(int postId)
        {
            return await _context.UniComments
                .Where( l => l.UniPostId == postId)
                .FirstOrDefaultAsync(l => l.IsFavorite == true);
                
        }

        public async Task<List<UniComment>> GetUniCommentsByPostId(int postId)
        {
            return await _context.UniComments
                    .Where(l => l.UniPostId == postId)
                    .ToListAsync();
        }
    }
}