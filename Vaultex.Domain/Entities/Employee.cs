using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex.Domain.Common;

namespace Vaultex.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string OrganisationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Organisation Organisation { get; set; }
    }
}
