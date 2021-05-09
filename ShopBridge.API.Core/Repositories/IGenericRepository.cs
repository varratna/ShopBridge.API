using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.API.Core.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(long id);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity, Object key);
        Task<TEntity> Delete(long id);
    }
}
