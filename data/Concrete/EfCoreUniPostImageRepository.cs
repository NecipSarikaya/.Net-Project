using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace data.Concrete
{
    public class EfCoreUniPostImageRepository: EfCoreGenericRepository<UniPostImage>, IUniPostImageRepository
    {
        private MentorContext _context;
        private IConfiguration _configuration;
        public EfCoreUniPostImageRepository(IConfiguration configuration,MentorContext context) :base(context)
        {
            _configuration = configuration;
            _context = context;
        }
        public async Task<bool> HasImage(int postId)
        {
            return await _context.UniPostImages
                .AnyAsync(l => l.UniPostId == postId);
        }

        public async Task<List<string>> GetImages(int postId)
        {
            return await  _context.UniPostImages
                .Where(l => l.UniPostId == postId)
                .Select(l => _configuration["Data:ImageUrl"]+l.ImageUrl).ToListAsync();
        }
    }
}