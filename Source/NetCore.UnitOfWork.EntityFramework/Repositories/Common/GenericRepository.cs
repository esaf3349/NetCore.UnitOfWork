using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        protected readonly ILogger Logger;

        public GenericRepository(AppDbContext dbContext, ILogger logger)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
            Logger = logger;
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"{typeof(GenericRepository<TEntity>)}: Add operation error");
                return false;
            }

            return true;
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            try
            {
                var existingEntity = await DbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

                if (existingEntity == null)
                    return false;

                DbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"{typeof(GenericRepository<TEntity>)}: Update operation error");
                return false;
            }

            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            try 
            {
                var existingEntity = await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (existingEntity == null)
                    return false;

                DbSet.Remove(existingEntity);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"{typeof(GenericRepository<TEntity>)}: Delete operation error");
                return false;
            }
            

            return true;
        }

        public virtual async Task<TEntity> Get(int id)
        {
            try
            {
                return await DbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"{typeof(GenericRepository<TEntity>)}: Get by id operation error");
                return null;
            }
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize)
        {
            try
            {
                return await DbSet.Where(filter).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"{typeof(GenericRepository<TEntity>)}: Get by filter operation error");
                return null;
            }
        }
    }
}
