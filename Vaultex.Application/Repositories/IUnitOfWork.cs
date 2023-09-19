namespace Vaultex.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IOrganisationRepository OrganisationRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        Task<int> Save(CancellationToken cancellationToken);
    }
}
