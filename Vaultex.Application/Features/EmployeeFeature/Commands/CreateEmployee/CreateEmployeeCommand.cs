using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex.Application.DTOs.Employee.Request;
using Vaultex.Application.DTOs.Employee.Response;
using Vaultex.Application.DTOs.Organisation.Request;
using Vaultex.Application.DTOs.Organisation.Response;
using Vaultex.Domain.Entities;
using Vaultex.Shared;

namespace Vaultex.Application.Features.EmployeeFeature.Commands.CreateEmployee
{
    public record CreateEmployeeCommand : IRequest<Result<IEnumerable<GetEmployeeResponse>>>
    {
        public List<CreateEmployeeRequest> CreateEmployeeRequests { get; set; }
    }
}
