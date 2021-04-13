using System.Collections.Generic;
using System.Threading.Tasks;
using business.Abstract;
using data.Abstract;
using entity;

namespace business.Concrete
{
    public class UniPostManager : IUniPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UniPostManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UniPost> Create(UniPost unipost)
        {
            if(string.IsNullOrEmpty(unipost.Content) || string.IsNullOrEmpty(unipost.Title) || unipost.UserId == 0 || unipost.UniversityId == 0 || unipost.PublishDate == null)
            {
                return null;
            }else{
                return await _unitOfWork.uniPostRepository.Create(unipost);
            }
        }

        public async Task<UniPost> Delete(UniPost entity)
        {
            if(entity.Id == 0){
                return null;
            }else{
                return await _unitOfWork.uniPostRepository.Delete(entity);            
            }
        }

        public async Task<List<UniPost>> GetAll()
        {
            return await _unitOfWork.uniPostRepository.GetAll();
        }

        public async Task<List<UniPost>> GetAllAdmin()
        {
            return await _unitOfWork.uniPostRepository.GetAllAdmin();
        }

        public async Task<List<UniPost>> GetAllUniPosts()
        {
            return await _unitOfWork.uniPostRepository.GetAllUniPosts();
        }

        public async Task<List<UniPost>> GetAllUniPostsByDepartment(string uniNameUrl, string departmenName,int page,int pageSize)
        {
            if(string.IsNullOrEmpty(uniNameUrl) || string.IsNullOrEmpty(departmenName)|| page == 0 || pageSize == 0)
                return null;
            else
                return await _unitOfWork.uniPostRepository.GetAllUniPostsByDepartment(uniNameUrl,departmenName,page,pageSize);
        }

        public async Task<List<UniPost>> GetAllUniPostsByUniUrl(string uniNameUrl,int page,int pageSize)
        {
            if(string.IsNullOrEmpty(uniNameUrl) || page == 0 || pageSize == 0)
                return null;
            else
                return await _unitOfWork.uniPostRepository.GetAllUniPostsByUniUrl(uniNameUrl,page,pageSize);
        }

        public async Task<UniPost> GetById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.uniPostRepository.GetById(id);
        }

        public async Task<int> GetCountByUniDepNameUrl(string uniNameUrl, string depNameUrl)
        {
            if(string.IsNullOrEmpty(uniNameUrl) || string.IsNullOrEmpty(depNameUrl))
                return 0;
            else
                return await _unitOfWork.uniPostRepository.GetCountByUniDepNameUrl(uniNameUrl,depNameUrl);
        }

        public async Task<int> GetCountByUniNameUrl(string uniNameUrl)
        {
            if(string.IsNullOrEmpty(uniNameUrl) || string.IsNullOrEmpty(uniNameUrl))
                return 0;
            else
                return await _unitOfWork.uniPostRepository.GetCountByUniNameUrl(uniNameUrl);
        }

        public  async Task<UniPost> GetUniPostById(int id)
        {
            if(id == 0)
                return null;
            else
                return await _unitOfWork.uniPostRepository.getUniPostById(id);
        }

        public async Task<UniPost> Update(UniPost unipost)
        {
            if(string.IsNullOrEmpty(unipost.Title) || unipost.UserId == 0 || unipost.UniversityId == 0 || string.IsNullOrEmpty(unipost.Content) || unipost.Id == 0)
                return null;
            else
                return await _unitOfWork.uniPostRepository.Update(unipost);
        }
    }
}