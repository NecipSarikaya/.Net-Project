using System.Collections.Generic;
using System.Threading.Tasks;
using data.Abstract;
using entity;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreDeparmentRepository : EfCoreGenericRepository<Department>, IDepartmentRepository
    {
        private MentorContext _context;
        public EfCoreDeparmentRepository(MentorContext context) :base(context)
        {
            _context = context;
        }
        public async Task<Department> GetDepartmentByUrl(string depNameUrl)
        {
            return await _context.Departments.FirstOrDefaultAsync(l => l.NameUrl == depNameUrl);
        }
    }
}