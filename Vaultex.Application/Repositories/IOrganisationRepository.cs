using Vaultex.Domain.Entities;

namespace Vaultex.Application.Repositories
{
    public interface IOrganisationRepository : IRepository<Organisation>
    {
        Task<Organisation> GetOrganisationByNumber(string orgNumber);
    }
}
