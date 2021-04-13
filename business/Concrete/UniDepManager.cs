using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class UniDepManager : IUniDepService
    {
        private IUniDepRepository _uniDepRepository;
        public UniDepManager(IUniDepRepository uniDepRepository)
        {
            _uniDepRepository = uniDepRepository;
        }

        public async Task<UniversityDepartment> Create(UniversityDepartment entity)
        {
            if(entity.DepartmentId == 0 || entity.UniversityId == 0)
                return null;
            else
                return await _uniDepRepository.Create(entity);
        }

        public async Task<UniversityDepartment> Delete(UniversityDepartment entity)
        {
            if(entity.DepartmentId == 0 || entity.UniversityId == 0)
                return null;
            else
                return await _uniDepRepository.Delete(entity);
        }

        public async Task<List<UniversityDepartment>> GetAll()
        {
            return await _uniDepRepository.GetAll();
        }

        public async Task<List<UniversityDepartment>> GetAllDepByUni(string uniNameUrl)
        {
            if(string.IsNullOrEmpty(uniNameUrl))
                return null;
            else
                return await _uniDepRepository.GetAllDepByUni(uniNameUrl);
        }

        public async Task<UniversityDepartment> GetById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _uniDepRepository.GetById(id);
        }

        public async Task<UniversityDepartment> GetDepById(int uniId, int depId)
        {
            if(uniId == 0 || depId == 0)
                return null;
            else
                return await _uniDepRepository.GetDepById(uniId,depId);
        }

        public async Task<UniversityDepartment> Update(UniversityDepartment entity)
        {
            if(entity.DepartmentId == 0 || entity.UniversityId == 0)
                return null;
            else
                return await _uniDepRepository.Update(entity);
        }
    }
}