using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaultex.Application.DTOs.Employee.Request
{
    public class CreateEmployeeRequest
    {
        public int OrganisationId { get; set; }
        public string OrganisationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
