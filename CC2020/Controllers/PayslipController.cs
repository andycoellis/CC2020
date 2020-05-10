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
            return View();
        }

    }
}
