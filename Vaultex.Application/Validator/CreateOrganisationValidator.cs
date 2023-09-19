using FluentValidation;
using Vaultex.Application.DTOs.Organisation.Request;

namespace Vaultex.Application.Validator
{
    public class CreateOrganisationValidator : AbstractValidator<CreateOrganisationRequest>
    {
        public CreateOrganisationValidator()
        {
            RuleFor(x => x.OrganisationName)
                .NotEmpty()
                .WithMessage("Organisation Name is Mandantory");

            RuleFor(x => x.OrganisationNumber)
                .NotEmpty()
                .WithMessage("Organisation Number is Mandantory");

            RuleFor(x => x.AddressLine1)
                .NotEmpty()
                .WithMessage("Address Line 1 is Mandantory");

            RuleFor(x => x.Postcode)
                .NotEmpty()
                .WithMessage("Post code is Mandantory");

            RuleFor(x => x.Town)
                .NotEmpty()
                .WithMessage("Town is Mandatory");
        }
    }
}
