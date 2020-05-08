using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC2020.Data;
using CC2020.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CC2020.Controllers
{
    public class TimesheetController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ILogger _logger;

        public TimesheetController(ApplicationDbContext context, ILogger<TimesheetController> logger)
        {
            unitOfWork = new UnitOfWork(context);
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(Timesheet timesheet)
        {
            try
            {
                var checkEmp = unitOfWork.Employees.SingleOrDefault(x => x.EmployeeID == timesheet.EmployeeID);
                var checkComp = unitOfWork.Companies.SingleOrDefault(x => x.ABN == timesheet.CompanyID);

                if (checkEmp == null || checkComp == null)
                {
                    new RedirectToActionResult("Index", "Home", null);
                }

                unitOfWork.Timesheets.Add(timesheet);
            }

            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return View();
        }

        public IActionResult Delete(int timesheetID)
        {
            try
            {
                var check = unitOfWork.Timesheets.SingleOrDefault(x => x.ID == timesheetID);

                if (check == null)
                {
                    new RedirectToActionResult("Index", "Home", null);
                }

                unitOfWork.Timesheets.Remove(check);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return View();
        }
    }
}
