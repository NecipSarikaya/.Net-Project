using System.Collections.Generic;
using System.Threading.Tasks;
using entity;

namespace business.Abstract
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetCategoryByNameUrl(string nameUrl);
    }
}