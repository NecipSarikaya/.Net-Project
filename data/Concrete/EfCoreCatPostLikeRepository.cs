using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreCatPostLikeRepository : EfCoreGenericRepository<CatPostUserLike>, ICatPostLikeRepository
    {
        private MentorContext _context;
        public EfCoreCatPostLikeRepository(MentorContext context) :base(context)
        {
            _context = context;
        }
        public async Task<CatPostUserLike> AlreadyLiked(int userId, int postId)
        {
            return await _context.CatPostUserLikes
                .Where(l => l.UserId == userId && l.CatPostId == postId)
                .FirstOrDefaultAsync();
        }
    }
}