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
using X.PagedList;
using System.Collections;

namespace CC2020.Controllers
{
    [Authorize]
    public class PayslipController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<Employee> _userManager;

        private readonly BusinessFacade businessRules;


        private readonly ILogger _logger;

        public PayslipController(UserManager<Employee> userManager, ApplicationDbContext context, ILogger<PayslipController> logger)
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

                ViewBag.userId = userId;
                ViewBag.name = unitOfWork.Employees.SingleOrDefault(x => x.Id == userId).Name;

                var payAgreements = unitOfWork.Employees.GetEmployeePayAgreements(userId);

                List<long> ABNs = new List<long>();

                List<string> companies = new List<string>();

                for (int i = 0; i < payAgreements.Count(); i++)
                {
                    long ABN = payAgreements.ElementAt(i).CompanyABN;
                    ABNs.Add(ABN);
                }

                for (int i = 0; i < ABNs.Count(); i++)
                {
                    string company = unitOfWork.Companies.getCompanyName(ABNs[i]);
                    companies.Add(company);
                }

                ViewBag.companies = companies;

                ViewBag.ABNs = ABNs;

                return View();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return new RedirectToActionResult("Index", "Home", null);
        }

        public IActionResult Create(string companyName, string userID, int? page)
        {
            try
            {
                ViewBag.CompanyName = companyName;

                ViewBag.ID = userID;

                long ABN = unitOfWork.Companies.getCompanyABN(companyName);

                var allPaySlips = unitOfWork.Employees.GetEmployeePaySlips(userID);

                List<Payslip> relevantPayslips = new List<Payslip>();

                for (int i = 0; i < allPaySlips.Count(); i++)
                {
                    if (allPaySlips.ElementAt(i).CompanyABN == ABN)
                    {
                        relevantPayslips.Add(allPaySlips.ElementAt(i));
                    }
                }

                var pageNumber = page ?? 1;

                var onePageOfPayslips = relevantPayslips.ToPagedList(pageNumber, 4);

                ViewBag.onePageOfPayslips = onePageOfPayslips;

                return View();

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);                
            }

            return new RedirectToActionResult("Index", "Home", null);
        } 
    }
}
