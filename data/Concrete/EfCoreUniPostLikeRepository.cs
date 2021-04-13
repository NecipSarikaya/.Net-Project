using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreUniPostLikeRepository : EfCoreGenericRepository<UniPostUserLike>, IUniPostLikeRepository
    {
        private MentorContext _context;
        public EfCoreUniPostLikeRepository(MentorContext context) :base(context)
        {
            _context = context;
        }
        public async Task<UniPostUserLike> AlreadyLiked(int userId, int postId)
        {
            return await _context.UniPostUserLikes
                .Where(l => l.UserId == userId && l.UniPostId == postId)
                .FirstOrDefaultAsync();
        }
    }
}