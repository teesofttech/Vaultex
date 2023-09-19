using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex.Domain.Common;

namespace Vaultex.Domain.Entities
{
    public class Organisation : BaseEntity
    {
        public string OrganisationName { get; set; }
        public string OrganisationNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? AddressLine4 { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }

    }
}
