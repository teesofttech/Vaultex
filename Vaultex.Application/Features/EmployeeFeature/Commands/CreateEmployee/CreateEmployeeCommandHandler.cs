using AutoMapper;
using MediatR;
using Vaultex.Application.DTOs.Employee.Request;
using Vaultex.Application.DTOs.Employee.Response;
using Vaultex.Application.DTOs.Organisation.Request;
using Vaultex.Application.DTOs.Organisation.Response;
using Vaultex.Application.Repositories;
using Vaultex.Domain.Entities;
using Vaultex.Shared;

namespace Vaultex.Application.Features.EmployeeFeature.Commands.CreateEmployee
{
    internal class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Result<IEnumerable<GetEmployeeResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<GetEmployeeResponse>>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            List<Employee> employees = new();
            var org = _mapper.Map<IEnumerable<CreateEmployeeRequest>, IEnumerable<Employee>>(command.CreateEmployeeRequests);
            foreach (var item in org)
            {
                var fetchOrg = await _unitOfWork.OrganisationRepository.GetOrganisationByNumber(item.OrganisationNumber);
                if (fetchOrg != null)
                    employees.Add(item);
            }
            IEnumerable<Employee> response = await _unitOfWork.EmployeeRepository.AddBulkAsync(employees);
            await _unitOfWork.Save(cancellationToken);

            var mappedOrg = _mapper.Map<IEnumerable<Employee>, IEnumerable<GetEmployeeResponse>>(response);

            return await Result<IEnumerable<GetEmployeeResponse>>.SuccessAsync(mappedOrg, "Employee Created.");
        }
    }
}
