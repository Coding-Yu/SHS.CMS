using SHS.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SHS.Domain.Repository.Interfaces
{
    public interface IRepository<Tentity> : IDisposable where Tentity : class
    {
        Tentity Add(Tentity obj);
        Task<Tentity> AddByAsync(Tentity obj);
        Tentity Get(object key);
        Task<Tentity> GetByAsync(string key);
        IEnumerable<Tentity> GetAll();
        Task<IEnumerable<Tentity>> GetAllByAsync();
        int Update(Tentity obj);
        Task<int> UpdateByAsync(Tentity obj);
        Task<int> UpdateByAsync(Tentity obj, Expression<Func<Tentity, object>> expression);
        int Remove(Tentity entity);
        Task<int> RemoveByAsync(Tentity entity);
        Task<int> RemoveByAsync(IEnumerable<Tentity> entities);
        Task<int> RemoveByAsync(object key);
        int SaveChanges();

    }
}
