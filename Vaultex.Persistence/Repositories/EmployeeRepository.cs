using Vaultex.Application.Repositories;
using Vaultex.Domain.Entities;
using Vaultex.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Vaultex.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly VaultexContext dbContext;
        public EmployeeRepository(VaultexContext _DbContext) : base(_DbContext)
        {
            dbContext = _DbContext;
        }
    }

}

