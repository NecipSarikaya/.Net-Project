using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreUniDepRepository : EfCoreGenericRepository<UniversityDepartment>, IUniDepRepository
    {
        private MentorContext _context;
        public EfCoreUniDepRepository(MentorContext context) :base(context)
        {
            _context = context;
        }
        public async Task<List<UniversityDepartment>> GetAllDepByUni(string uniNameUrl)
        {
                return await _context.UniversityDepartments
                        .Include(l => l.University)
                        .Where( l => l.University.NameUrl == uniNameUrl)
                        .ToListAsync();
        }

        public async Task<UniversityDepartment> GetDepById(int uniId, int depId)
        {
                return await _context.UniversityDepartments
                    .Where(l => l.DepartmentId == depId)
                    .FirstOrDefaultAsync(l => l.UniversityId == uniId);
        }
    }
}