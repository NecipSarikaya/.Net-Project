using System.Collections.Generic;
using System.Threading.Tasks;
using data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace data.Concrete
{
    public class EfCoreGenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private MentorContext _context;
        public EfCoreGenericRepository(MentorContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
                if(await _context.SaveChangesAsync() > 0){
                    return entity;
                }else{
                    return null;
                }
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            if(await _context.SaveChangesAsync() > 0){
                return entity;
            }else{
                return null;
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            if(await _context.SaveChangesAsync() > 0){
                return entity;
            }else{
                return null;
            }
        }
    }
}