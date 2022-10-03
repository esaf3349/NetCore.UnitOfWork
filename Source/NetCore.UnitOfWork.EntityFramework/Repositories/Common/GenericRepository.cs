using Microsoft.EntityFrameworkCore;
using NetCore.UnitOfWork.Core.Entities.Common;
using NetCore.UnitOfWork.Interfaces.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NetCore.UnitOfWork.EntityFramework.Repositories.Common
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : IntKeyEntity
    {
        protected AppDbContext DbContext;
        protected DbSet<TEntity> DbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);

            return true;
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            var existingEntity = await DbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            if (existingEntity != null)
                return false;

            DbSet.Update(entity);

            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            var existingEntity = await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (existingEntity == null) 
                return false;

            DbSet.Remove(existingEntity);

            return true;
        }

        public virtual async Task<TEntity> Get(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter, int pageNumber = 1, int pageSize = 20)
        {
            return await DbSet.Where(filter).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
