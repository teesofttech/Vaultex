using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex.Application.DTOs.Employee.Response;
using Vaultex.Application.DTOs.Organisation.Response;
using Vaultex.Application.Repositories;
using Vaultex.Shared;

namespace Vaultex.Application.Features.EmployeeFeature.Queries
{

    public record GetAllEmployeeQuery : IRequest<Result<List<GetEmployeeResponse>>>;

    internal class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, Result<List<GetEmployeeResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllEmployeeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetEmployeeResponse>>> Handle(GetAllEmployeeQuery query, CancellationToken cancellationToken)
        {
            var emp = await _unitOfWork.EmployeeRepository.GetAllAsync();
            var mapped = _mapper.Map<List<GetEmployeeResponse>>(emp);
            return await Result<List<GetEmployeeResponse>>.SuccessAsync(mapped);
        }
    }
}
