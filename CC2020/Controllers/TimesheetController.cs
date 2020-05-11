using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CC2020.Data;
using CC2020.Models;
using CC2020.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CC2020.Controllers
{
    [Authorize]
    public class TimesheetController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<Employee> _userManager;

        private readonly BusinessFacade businessRules;


        private readonly ILogger _logger;

        public TimesheetController(UserManager<Employee> userManager, ApplicationDbContext context, ILogger<TimesheetController> logger)
        {
            unitOfWork = new UnitOfWork(context);
            businessRules = new BusinessFacade();

            _userManager = userManager;

            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                return View();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return new RedirectToActionResult("Index", "Home", null);
        }

        public IActionResult Create()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var payAgrements = unitOfWork.Employees.GetEmployeePayAgreements(userId);

                ViewBag.AllPayAgreements = payAgrements;
                List<double> breakTimes = new List<double> { 0, 0.5, 1 };
                ViewBag.BreakTimes = breakTimes;

                var timesheet = new Timesheet { EmployeeID = userId };

                return View(timesheet);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);                
            }

            return new RedirectToActionResult("Index", "Home", null);
        }

        [HttpPost]
        public IActionResult Create(Timesheet timesheet)
        {
            try
            {
                if (timesheet == null)
                {
                    new RedirectToActionResult("Index", "Home", null);
                }

                unitOfWork.Timesheets.Add(timesheet);
                unitOfWork.Complete();
            }
            catch (Exception e)

            {
                _logger.LogError(e.Message);
            }

            return RedirectToAction(nameof(Index));
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
