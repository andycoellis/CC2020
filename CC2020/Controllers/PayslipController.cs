using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC2020.Data;
using CC2020.Models;
using CC2020.Services;
using Microsoft.AspNetCore.Mvc;


namespace CC2020.Controllers
{
    public class PayslipController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly BusinessFacade businessRules;

        public PayslipController(ApplicationDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
            businessRules = new BusinessFacade();
        }

        public IActionResult Index()
        {

            var empID = 4444;
            var companyID = 40907025013;
            var startDate = new DateTime(2020, 2, 17);
            var endDate = startDate.AddDays(8);

            var payagreement = unitOfWork.PayAgreements.SingleOrDefault(
                x => x.EmployeeID == empID && x.CompanyID == companyID);

            var employee = unitOfWork.Employees.SingleOrDefault(x => x.EmployeeID == empID);
            var company = unitOfWork.Companies.SingleOrDefault(x => x.ABN == companyID);

            var timesheets = unitOfWork.Timesheets.Find(
                x => x.EmployeeID == empID && x.CompanyID == companyID
                ).Where(x => x.Date.Date >= startDate && x.Date.Date < endDate);


            var foo = businessRules.EmployeeWeeklyTimeSheet(employee, company, timesheets.ToList(), payagreement, 999);

            return View();
        }
    }
}
