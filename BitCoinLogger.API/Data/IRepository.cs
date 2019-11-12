using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BitcoinLogger.Api.Data.Models;

namespace BitcoinLogger.Api.Data
{
    public interface IRepository<T> where T : IModelBase
    {
        T GetOrDefault(long id);
        IQueryable<T> GetAsQueryable(Expression<Func<T, bool>> filter = null);

        IEnumerable<T> GetAsEnumerable();
        Task<List<T>> GetAsEnumerableAsync();

        T Add(T item);
        Task<T> AddAsync(T item);

        void Remove(long id);

        void Update(T item);

        void Save();
        Task SaveAsync();

        bool Any(Func<T, bool> filter = null);
        Task<bool> AnyAsync(Func<T, bool> filter = null);
    }
}