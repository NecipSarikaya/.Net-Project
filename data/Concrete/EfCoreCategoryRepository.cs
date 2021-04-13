using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        private MentorContext _context;
        public EfCoreCategoryRepository(MentorContext context) :base(context)
        {
            _context = context;
        }
        public async Task<Category> GetCategoryByNameUrl(string nameUrl)
        {
            return await _context.Categories.FirstOrDefaultAsync(l => l.NameUrl == nameUrl);
        }
    }
}