using Vaultex.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex.Application.Repositories;

namespace Vaultex.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VaultexContext _dbContext;
        private bool disposed;

        public UnitOfWork(VaultexContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        private IOrganisationRepository _OrganisationRepository;
        public IOrganisationRepository OrganisationRepository
        {
            get
            {
                if (_OrganisationRepository == null)
                {
                    _OrganisationRepository = new OrganisationRepository(_dbContext);
                }
                return _OrganisationRepository;
            }
        }


        private IEmployeeRepository _employeeRepository;
        public IEmployeeRepository EmployeeRepository
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_dbContext);
                }
                return _employeeRepository;
            }
        }
        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _dbContext.Dispose();
                }
            }
            //dispose unmanaged resources
            disposed = true;
        }


    }
}
