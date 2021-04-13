using System.Threading.Tasks;
using entity;

namespace data.Abstract
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> GetCategoryByNameUrl(string nameUrl);
    }
}