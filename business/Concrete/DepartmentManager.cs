using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Department> Create(Department entity)
        {
            if(string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.NameUrl))
                return null;
            else
                return await _unitOfWork.departmentRepository.Create(entity);
        }

        public async Task<Department> Delete(Department entity)
        {
            if(entity.Id == 0)
                return null;
            else
                return await _unitOfWork.departmentRepository.Delete(entity);
        }

        public async Task<List<Department>> GetAll()
        {
            return  await _unitOfWork.departmentRepository.GetAll();        
        }

        public async Task<Department> GetById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.departmentRepository.GetById(id);
        }

        public async Task<Department> GetDepartmentByUrl(string depNameUrl)
        {
            if(string.IsNullOrEmpty(depNameUrl))
                return null;
            else
                return await _unitOfWork.departmentRepository.GetDepartmentByUrl(depNameUrl);
        }

        public async Task<Department> Update(Department entity)
        {
            if(string.IsNullOrEmpty(entity.Name) ||string.IsNullOrEmpty(entity.NameUrl))
                return null;
            else
                return await _unitOfWork.departmentRepository.Update(entity);
        }
    }
}