using NetCore.UnitOfWork.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore.UnitOfWork.Interfaces.Repositories.Common
{
    public interface IGenericRepository<TEntity> where TEntity : IntKeyEntity
    {
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize);
    }
}
