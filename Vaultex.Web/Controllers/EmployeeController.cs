using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vaultex.Application.Features.EmployeeFeature.Queries;
using Vaultex.Application.Features.OrganisationFeature.Queries;

namespace Vaultex.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllEmployeeQuery()); 
            return View(result);
        }
    }
}
