using Azure.Core;
using ExcelDataReader;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using Vaultex.Application.DTOs.Organisation.Request;
using Vaultex.Application.Features.OrganisationFeature.Commands.CreateOrganisation;
using Vaultex.Application.Repositories;
using Vaultex.Application.Validator;
using Vaultex.Shared;
using Vaultex.Web.Models;

namespace Vaultex.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
    
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}