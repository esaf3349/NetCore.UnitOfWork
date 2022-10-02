using NetCore.UnitOfWork.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore.UnitOfWork.Interfaces.Repositories.Common
{
    public interface IGenericRepository<T> where T : IntKeyEntity
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter, int take, int offset);
    }
}
