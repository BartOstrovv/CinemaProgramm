using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public interface IRepository<TEntity>
    {
        Task<IReadOnlyCollection<TEntity>> GetAllAsync();
        Task<IReadOnlyCollection<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicat);
        Task CreateAsync(TEntity entity);
    }
}
