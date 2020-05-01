using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using SHS.Domain.Core.Interfaces;
using SHS.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SHS.Domain.Repository.Interfaces
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly CMSContext _dbContext;
        public readonly DbSet<TEntity> DbSet;
        public Repository(CMSContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public TEntity Add(TEntity obj)
        {
            DbSet.Add(obj);
            _dbContext.SaveChanges();
            return obj;
        }

        public async Task<TEntity> AddByAsync(TEntity obj)
        {
            _dbContext.Add(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public TEntity Get(object key)
        {
            return DbSet.Find(key);
        }

        public async Task<IEnumerable<TEntity>> GetAllByAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public async Task<TEntity> GetByAsync(string key)
        {
            Guid Fkey = new Guid();
            Guid.TryParse(key, out Fkey);
            if (!string.IsNullOrWhiteSpace(key.ToString()))
            {
                return await DbSet.FindAsync(Fkey);
            }
            return null;
        }

        public int Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public async Task<int> RemoveByAsync(TEntity tentity)
        {
            var entity = _dbContext.Entry(tentity);
            if (tentity != null)
            {
                entity.State = EntityState.Modified;
                entity.Property("IsDel").IsModified = true;
                entity.Property("DeleteUserId").IsModified = true;
                entity.Property("DeleteDate").IsModified = true;
                await UpdateByAsync(tentity);
            }
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveByAsync(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> RemoveByAsync(object key)
        {
            var entity = Get(key);
            var entry = _dbContext.Entry(Get(key));
            if (entity != null)
            {
                entry.State = EntityState.Modified;
                entry.Property("IsDel").IsModified = true;
                entry.Property("DeleteUserId").IsModified = true;
                entry.Property("DeleteDate").IsModified = true;
                await UpdateByAsync(entity);
            }
            return await _dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public int Update(TEntity obj)
        {
            DbSet.Update(obj);
            return _dbContext.SaveChanges();
        }

        public async Task<int> UpdateByAsync(TEntity obj)
        {
            //_dbContext.Entry(obj).CurrentValues.SetValues(obj);
            //var entity = _dbContext.Entry(obj);
            //entity.State = EntityState.Unchanged;
            _dbContext.Update(obj);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> UpdateByAsync(TEntity obj, Expression<Func<TEntity, object>> expression)
        {
            //Owned Reference
            // var entity = _dbContext.Entry(obj);
            var entity = _dbContext.Set<TEntity>().Attach(obj);
            //entity.State = EntityState.Modified;
            entity.Property("CreateUserId").IsModified = false;
            entity.Property("CreateDate").IsModified = false;
            foreach (var item in expression.GetPropertyAccessList())
            {
                // ((IObjectContextAdapter)_dbContext).ObjectContext.ObjectStateManager.ChangeRelationshipState(sourceEntity, targetEntity, navigationPropertySelector, relationshipState);
                if (!string.IsNullOrWhiteSpace(item.Name))
                {
                    entity.Property(item.Name).IsModified = true;
                }
            }
            _dbContext.Update(obj);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
