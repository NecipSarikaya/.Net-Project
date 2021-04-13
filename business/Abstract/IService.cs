using System.Collections.Generic;
using System.Threading.Tasks;

namespace business.Abstract
{
    public interface IService<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
    }
}