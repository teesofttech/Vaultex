using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex.Application.DTOs.Organisation.Request;
using Vaultex.Application.DTOs.Organisation.Response;
using Vaultex.Domain.Entities;
using Vaultex.Shared;

namespace Vaultex.Application.Features.OrganisationFeature.Commands.CreateOrganisation
{
    public record CreateOrganisationCommand : IRequest<Result<IEnumerable<GetOrganisationResponse>>>
    {
        public List<CreateOrganisationRequest> CreateOrganisationRequests { get; set; }
    }
}
