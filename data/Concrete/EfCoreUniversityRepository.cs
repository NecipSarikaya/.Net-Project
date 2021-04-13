using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreUniversityRepository : EfCoreGenericRepository<University>, IUniversityRepository
    {
        private MentorContext _context;
        public EfCoreUniversityRepository(MentorContext context) :base(context)
        {
            _context = context;
        }

        public async Task<List<University>> GetAllByOrdered()
        {
            return await _context.Universities.OrderBy(l =>l.Id)
                        .ToListAsync();
        }

        public async Task<University> GetUniByUniNameUrl(string uniNameUrl)
        {
            return await _context.Universities.FirstOrDefaultAsync(l => l.NameUrl == uniNameUrl);
        }

        public async Task<bool> HasADepartment(int uniId,int depId)
        {
            var result = await _context.UniversityDepartments
                .Where(l => l.UniversityId == uniId && l.DepartmentId == depId)
                .FirstOrDefaultAsync();
            if(result == null)
                return false;
            else
                return true;
        }
    }
}