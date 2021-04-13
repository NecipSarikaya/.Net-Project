using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreCatCommentLikeRepository : EfCoreGenericRepository<CatCommentUserLike>, ICatCommentLikeRepository
    {
        private MentorContext _context;
        public EfCoreCatCommentLikeRepository(MentorContext context):base (context)
        {
            _context = context;
        }
        public async Task<CatCommentUserLike> AlreadyLiked(int userId, int postId)
        {
            return await _context.CatCommentUserLikes
                .Where(l => l.UserId == userId)
                .FirstOrDefaultAsync(l => l.CatCommentId == postId);
        }
    }
}