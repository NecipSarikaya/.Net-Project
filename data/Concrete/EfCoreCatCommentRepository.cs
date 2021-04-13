using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreCatCommentRepository : EfCoreGenericRepository<CatComment>, ICatCommentRepository
    {
        private MentorContext _context;
        public EfCoreCatCommentRepository(MentorContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<CatComment>> GetAllCatComments()
        {
            return await _context.CatComments
                .Include(l => l.User)
                .ToListAsync();
        }

        public async Task<CatComment> GetCatCommentById(int id)
        {
            return await _context.CatComments
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<CatComment> GetFavorite(int postId)
        {
            return await _context.CatComments
                .Where( l => l.CatPostId == postId)
                .FirstOrDefaultAsync(l => l.IsFavorite == true);
                
        }
    }
}