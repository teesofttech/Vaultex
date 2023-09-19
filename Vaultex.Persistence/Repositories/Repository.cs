using Vaultex.Application.Repositories;
using Vaultex.Application.Specifications;
using Vaultex.Domain.Common;
using Vaultex.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Vaultex.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly VaultexContext dbContext;

        protected Repository(VaultexContext _DbContext)
        {
            dbContext = _DbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> Update(T newEntity)
        {
            dbContext.Update<T>(newEntity);
            return newEntity;
        }

        public async Task<T> Delete(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetEntityWithSpec(ISpecifications<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }
        public async Task<int> CountAsync(ISpecifications<T> specifications)
        {
            return await ApplySpecification(specifications).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecifications<T> specifications)
        {
            return SpecificationEvaluator<T>.GetQuery(dbContext.Set<T>().AsQueryable(), specifications);
        }

        public async Task<IEnumerable<T>> AddBulkAsync(IEnumerable<T> entities)
        {
            await dbContext.Set<T>().AddRangeAsync(entities);
            return entities;
        }
    }
}
