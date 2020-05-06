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
    public class PayAgreementController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ILogger _logger;

        public PayAgreementController(ApplicationDbContext context, ILogger<PayAgreementController> logger)
        {
            unitOfWork = new UnitOfWork(context);
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(PayAgreement payAgreement)
        {
            try
            {
                var checkId = unitOfWork.PayAgreements.SingleOrDefault(x =>
                                            x.EmployeeID == payAgreement.EmployeeID &&
                                            x.CompanyID == payAgreement.CompanyID
                                            );
                if (checkId != null)
                {
                    new RedirectToActionResult("Index", "Home", null);
                }

                unitOfWork.PayAgreements.Add(payAgreement);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return View();
        }

        public IActionResult Edit(PayAgreement payAgreement)
        {
            try
            {
                var check = unitOfWork.PayAgreements.SingleOrDefault(x => x.ID == payAgreement.ID);

                if(check == null)
                {
                    new RedirectToActionResult("Index","Home",null);
                }

                unitOfWork.PayAgreements.Add(payAgreement);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
            return View();

        }
    }
}
