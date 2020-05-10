using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC2020.Data;
using CC2020.Models;
using CC2020.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CC2020.Controllers
{
    [Authorize]
    public class PayslipController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly BusinessFacade businessRules;

        private readonly ILogger _logger;

        public PayslipController(ApplicationDbContext context, ILogger<PayslipController> logger)
        {
            unitOfWork = new UnitOfWork(context);
            businessRules = new BusinessFacade();

            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                //var empID = 4444;
                //var companyID = 40907025013;
                //var startDate = new DateTime(2020, 2, 17);
                //var endDate = startDate.AddDays(8);

                //var payagreement = unitOfWork.PayAgreements.SingleOrDefault(
                //    x => x.EmployeeID == empID && x.CompanyID == companyID);

                //var employee = unitOfWork.Employees.SingleOrDefault(x => x.EmployeeID == empID);
                //var company = unitOfWork.Companies.SingleOrDefault(x => x.ABN == companyID);

                //var timesheets = unitOfWork.Timesheets.Find(
                //    x => x.EmployeeID == empID && x.CompanyID == companyID
                //    ).Where(x => x.Date.Date >= startDate && x.Date.Date < endDate);


                //var foo = businessRules.EmployeeWeeklyTimeSheet(employee, company, timesheets.ToList(), payagreement, 999);

            }

            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Timesheet timesheet)
        {
            try
            {
                //Extend the key id entry
                //var id = unitOfWork.Timesheets.GetAll().OrderByDescending(x => x.ID).FirstOrDefault().ID + 1;

                if(timesheet == null)
                {
                    new RedirectToActionResult("Index", "Home", null);
                }

                //timesheet.ID = id;
                unitOfWork.Timesheets.Add(timesheet);
                unitOfWork.Complete();
            }
            catch(Exception e)

            {
                _logger.LogError(e.Message);
            }
            return View();
        }
    }
}
