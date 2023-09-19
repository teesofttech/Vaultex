using ExcelDataReader;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Vaultex.Application.DTOs.Employee.Request;
using Vaultex.Application.DTOs.Organisation.Request;
using Vaultex.Application.Features.EmployeeFeature.Commands.CreateEmployee;
using Vaultex.Application.Features.OrganisationFeature.Commands.CreateOrganisation;
using Vaultex.Application.Features.OrganisationFeature.Queries;
using Vaultex.Application.Validator;

namespace Vaultex.Web.Controllers
{
    public class OrganisationController : Controller
    {
        private IMediator _mediator;
        public OrganisationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAllOrganisationQuery());
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile formFile)
        {
            #region Variable Declaration
            string message = "";
            DataSet dsexcelRecords = new DataSet();
            IExcelDataReader reader = null;
            #endregion
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            if (formFile != null)
            {
                if (formFile.FileName.EndsWith(".xls"))
                    reader = ExcelReaderFactory.CreateBinaryReader(formFile.OpenReadStream());
                else if (formFile.FileName.EndsWith(".xlsx"))
                    reader = ExcelReaderFactory.CreateOpenXmlReader(formFile.OpenReadStream());
                else
                    message = "The file format is not supported.";
                List<CreateOrganisationRequest> CreateOrganisationRequests = new List<CreateOrganisationRequest>();
                List<CreateEmployeeRequest> createEmployeeRequests = new List<CreateEmployeeRequest>();
                do
                {
                    if (reader.Name.Equals("Organisation", StringComparison.OrdinalIgnoreCase))
                    {
                        reader.Read();

                        while (reader.Read())
                        {
                            var createOrganisationRequest = new CreateOrganisationRequest()
                            {
                                OrganisationName = Convert.ToString(reader.GetString(0)),
                                OrganisationNumber = Convert.ToString(reader.GetString(1)),
                                AddressLine1 = Convert.ToString(reader.GetString(2)),
                                AddressLine2 = Convert.ToString(reader.GetString(3)),
                                AddressLine3 = Convert.ToString(reader.GetString(4)),
                                AddressLine4 = Convert.ToString(reader.GetString(5)),
                                Town = Convert.ToString(reader.GetString(6)),
                                Postcode = Convert.ToString(reader.GetString(7)),

                            };
                            var orgRequestValidator = new CreateOrganisationValidator();
                            var result = orgRequestValidator.Validate(createOrganisationRequest);
                            if (result.IsValid)
                            {
                                CreateOrganisationRequests.Add(createOrganisationRequest);
                            }
                        }
                        var request = new CreateOrganisationCommand()
                        {
                            CreateOrganisationRequests = CreateOrganisationRequests
                        };
                        var response = await _mediator.Send(request);
                    }
                    else
                    {
                        reader.Read(); //skip the header

                        while (reader.Read())
                        {
                            var createEmployeeRequest = new CreateEmployeeRequest()
                            {
                                OrganisationNumber = Convert.ToString(reader.GetString(0)),
                                FirstName = Convert.ToString(reader.GetString(1)),
                                LastName = Convert.ToString(reader.GetString(2))
                            };
                            var erpRequestValidator = new CreateEmployeeValidator();
                            var result = erpRequestValidator.Validate(createEmployeeRequest);
                            if (result.IsValid)
                            {
                                createEmployeeRequests.Add(createEmployeeRequest);
                            }
                        }
                        var request = new CreateEmployeeCommand()
                        {
                            CreateEmployeeRequests = createEmployeeRequests
                        };
                        var response = await _mediator.Send(request);
                    }

                } while (reader.NextResult());


                reader.Close();

                message = "Import completed";
                TempData["responseMsg"] = message;
                return RedirectToAction("Index");
            }
            else
            {
                message = "No file selected";
                TempData["responseMsg"] = message;
                return RedirectToAction("Index");
            }
        }
    }
}
