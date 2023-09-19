using AutoMapper;
using MediatR;
using Vaultex.Application.DTOs.Organisation.Request;
using Vaultex.Application.DTOs.Organisation.Response;
using Vaultex.Application.Repositories;
using Vaultex.Domain.Entities;
using Vaultex.Shared;

namespace Vaultex.Application.Features.OrganisationFeature.Commands.CreateOrganisation
{
    internal class CreateOrganisationCommandHandler : IRequestHandler<CreateOrganisationCommand, Result<IEnumerable<GetOrganisationResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrganisationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<GetOrganisationResponse>>> Handle(CreateOrganisationCommand command, CancellationToken cancellationToken)
        {
            var org = _mapper.Map<IEnumerable<CreateOrganisationRequest>, IEnumerable<Organisation>>(command.CreateOrganisationRequests);
            IEnumerable<Organisation> ress = await _unitOfWork.OrganisationRepository.AddBulkAsync(org);
            await _unitOfWork.Save(cancellationToken);

            var mappedOrg = _mapper.Map<IEnumerable<Organisation>, IEnumerable<GetOrganisationResponse>>(ress);

            return await Result<IEnumerable<GetOrganisationResponse>>.SuccessAsync(mappedOrg, "Organisation Created.");
        }
    }
}
