using System;
using CC2020.Data;
using CC2020.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CC2020.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ILogger _logger;

        public EmployeeController(ApplicationDbContext context, ILogger<EmployeeController> logger)
        {
            unitOfWork = new UnitOfWork(context);
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(Employee employee)
        {
            try
            {
                var check = unitOfWork.Employees.SingleOrDefault(x => x.EmployeeID == employee.EmployeeID);
                if (check != null)
                {
                    _logger.LogInformation("Attempted to create a user that already exists");
                    new RedirectToActionResult("Index", "Home", null);
                }

                unitOfWork.Employees.Add(employee);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return View();
        }
    }
}
