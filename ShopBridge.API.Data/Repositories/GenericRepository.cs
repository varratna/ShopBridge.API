using Microsoft.EntityFrameworkCore;
using ShopBridge.API.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.API.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private InventoryContext context;
        private DbSet<TEntity> dbSet;
        public GenericRepository(InventoryContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var result = await this.dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task<TEntity> Delete(long id)
        {
            TEntity entityToDelete = await dbSet.FindAsync(id);
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
            return entityToDelete;
        }

        public async Task<TEntity> Get(long id)
        {
            return await dbSet.FindAsync(id);
        }

        public  async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity, object key)
        {
            //dbSet.Attach(entity.);
            //context.Entry(entity).State = EntityState.Modified;
            if (entity == null)
                return null;
            TEntity exist = await this.dbSet.FindAsync(key);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(entity);                
            }
            return exist;
        }
    }
}
