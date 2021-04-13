using System.Collections.Generic;
using System.Threading.Tasks;

namespace data.Abstract
{
    public interface IRepository<TEntity>
    {
        Task<bool> SaveChanges();
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
    }
}