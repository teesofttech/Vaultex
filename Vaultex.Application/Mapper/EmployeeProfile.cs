using AutoMapper;
using Vaultex.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex.Application.DTOs.Employee.Request;
using Vaultex.Application.DTOs.Employee.Response;

namespace Vaultex.Application.Mapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, CreateEmployeeRequest>().ReverseMap();
            CreateMap<Employee, GetEmployeeResponse>().ReverseMap();
        }
    }
}
