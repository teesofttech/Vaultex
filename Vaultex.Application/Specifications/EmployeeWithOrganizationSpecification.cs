using Vaultex.Domain.Entities;

namespace Vaultex.Application.Specifications
{
    public class EmployeeWithOrganisationSpecification : BaseSpecification<Employee>
    {
        public EmployeeWithOrganisationSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(o => o.Organisation);
        }
    }
}