using Vaultex.Application.Repositories;
using Vaultex.Domain.Entities;
using Vaultex.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Vaultex.Persistence.Repositories
{
    public class OrganisationRepository : Repository<Organisation>, IOrganisationRepository
    {
        private readonly VaultexContext dbContext;
        public OrganisationRepository(VaultexContext _DbContext) : base(_DbContext)
        {
            dbContext = _DbContext;
        }

        public async Task<Organisation> GetOrganisationByNumber(string orgNumber)
        {
            return await dbContext.Organisations.Where(x => x.OrganisationNumber == orgNumber).FirstOrDefaultAsync();
        }
    }

}

