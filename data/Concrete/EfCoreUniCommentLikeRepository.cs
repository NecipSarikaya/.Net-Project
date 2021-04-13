using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreUniCommentLikeRepository : EfCoreGenericRepository<UniCommentUserLike>, IUniCommentLikeRepository
    {
        private MentorContext _context;
        public EfCoreUniCommentLikeRepository(MentorContext context):base (context)
        {
            _context = context;
        }
        public async Task<UniCommentUserLike> AlreadyLiked(int userId, int commentId)
        {
            return await _context.UniCommentUserLikes
                    .Where( l => l.UniCommentId == commentId)
                    .FirstOrDefaultAsync( l => l.UserId == userId);
        }
    }
}