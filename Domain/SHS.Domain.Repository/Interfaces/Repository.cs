using Microsoft.EntityFrameworkCore;
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
            DbSet.Add(obj);
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
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public async Task<TEntity> GetByAsync(string key)
        {
            Guid Fkey = new Guid();
            Guid.TryParse(key, out Fkey);
            if (!string.IsNullOrWhiteSpace(Fkey.ToString()))
            {
                return await DbSet.FindAsync();
            }
            return null;
        }

        public int Remove(TEntity entity)
        {
            DbSet.Remove(entity);
            return _dbContext.SaveChanges();
        }

        public async Task<int> RemoveByAsync(TEntity entity)
        {
            DbSet.Remove(entity);
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
            if (entity != null)
            {
                Remove(entity);
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
            DbSet.Update(obj);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
