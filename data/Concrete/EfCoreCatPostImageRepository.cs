using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace data.Concrete
{
    public class EfCoreCatPostImageRepository: EfCoreGenericRepository<CatPostImage>, ICatPostImageRepository
    {
        private MentorContext _context;
        private IConfiguration _configuration;
        public EfCoreCatPostImageRepository(IConfiguration configuration,MentorContext context) :base(context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<bool> GetImageByPostId(int postId)
        {
            return await _context.CatPostImages
                .AnyAsync(l => l.CatPostId == postId);
        }

        public async Task<List<string>> GetImages(int postId)
        {
            return await  _context.CatPostImages
                .Where(l => l.CatPostId == postId)
                .Select(l => _configuration["Data:ImageUrl"]+l.ImageUrl).ToListAsync();
        }
    }
}