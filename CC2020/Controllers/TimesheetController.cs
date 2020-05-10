using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC2020.Data;
using CC2020.Models;
using CC2020.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CC2020.Controllers
{
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
            return View("Create");
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
