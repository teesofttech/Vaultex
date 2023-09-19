using AutoMapper;
using MediatR;
using Vaultex.Application.DTOs.Organisation.Response;
using Vaultex.Application.Repositories;
using Vaultex.Shared;

namespace Vaultex.Application.Features.OrganisationFeature.Queries
{
    public record GetAllOrganisationQuery : IRequest<Result<List<GetOrganisationResponse>>>;

    internal class GetAllOrganisationQueryHandler : IRequestHandler<GetAllOrganisationQuery, Result<List<GetOrganisationResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrganisationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetOrganisationResponse>>> Handle(GetAllOrganisationQuery query, CancellationToken cancellationToken)
        {
            var org = await _unitOfWork.OrganisationRepository.GetAllAsync();
            var mapped = _mapper.Map<List<GetOrganisationResponse>>(org);
            return await Result<List<GetOrganisationResponse>>.SuccessAsync(mapped);
        }
    }
}
