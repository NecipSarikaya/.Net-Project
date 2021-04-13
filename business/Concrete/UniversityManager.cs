using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class UniversityManager : IUniversityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UniversityManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<University> Create(University entity)
        {
            if(string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.NameUrl))
                return null;
            else
                return await _unitOfWork.universityRepository.Create(entity);
        }

        public async Task<University> Delete(University entity)
        {
            if(entity.Id == 0)
                return null;
            else
                return await _unitOfWork.universityRepository.Delete(entity);
        }

        public async Task<List<University>> GetAll()
        {
            return await _unitOfWork.universityRepository.GetAll();
        }

        public async Task<List<University>> GetAllByOrdered()
        {
            return await _unitOfWork.universityRepository.GetAllByOrdered();
        }

        public async Task<University> GetById(int uniId)
        {
            if(uniId == 0)
                return null;
            else        
                return await _unitOfWork.universityRepository.GetById(uniId);
        }

        public async Task<University> GetUniByUniNameUrl(string uniNameUrl)
        {
            if(string.IsNullOrEmpty(uniNameUrl))
                return null;
            else
                return await _unitOfWork.universityRepository.GetUniByUniNameUrl(uniNameUrl);
        }

        public async Task<bool> HasADepartment(int uniId,int depId)
        {
            if(uniId == 0 || depId == 0)
                return false;
            else 
                return await _unitOfWork.universityRepository.HasADepartment(uniId,depId);
        }

        public async Task<University> Update(University entity)
        {
            if(string.IsNullOrEmpty(entity.NameUrl)|| string.IsNullOrEmpty(entity.Name))
                return null;
            else
                return await _unitOfWork.universityRepository.Update(entity);
        }
    }
}