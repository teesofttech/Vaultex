using Vaultex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaultex.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddBulkAsync(IEnumerable<T> entities);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetEntityWithSpec(ISpecifications<T> specification);
        Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> specification);

    }
}
