using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vaultex.Application.DTOs.Employee.Request;
using Vaultex.Application.DTOs.Organisation.Request;

namespace Vaultex.Application.Validator
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name is Mandantory");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Last Name is Mandantory");

            RuleFor(x => x.OrganisationNumber)
                .NotEmpty()
                .WithMessage("Organisation Number is Mandantory");

        }
    }
}
