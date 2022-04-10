using BenefitsCalculator.Interfaces;
using BenefitsCalculator.Model;
using BenefitsConsole.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsConsole.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBenefitsCalculator _benefitsCalculator;

        public HomeController(ILogger<HomeController> logger, IBenefitsCalculator benefitsCalculator)
        {
            _logger = logger;
            _benefitsCalculator = benefitsCalculator;
        }

        public IActionResult Index()
        {
            var employee = new Employee()
            {
                Name = "Andrea",
                Dependents = new List<Dependent>()
                {
                    new Dependent()
                    {
                        Name = "Barry"
                    },
                    new Dependent()
                    {
                        Name = "Danny"
                    }
                 }
            };

            var cost = _benefitsCalculator.GetBenefitsCostForEmployee(employee);

            return View(new BenefitsViewModel()
            {
                EmployeeName = employee.Name,
                DependentNames = employee.Dependents.Select(x => x.Name).ToList(),
                BenefitsCost = cost
            }
            );
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

        public IActionResult GetBenefits()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
