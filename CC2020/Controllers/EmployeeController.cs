using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CC2020.Data;
using CC2020.Models;
using CC2020.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CC2020.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<Employee> _userManager;

        private readonly ILogger _logger;

        public EmployeeController(UserManager<Employee> userManager, ApplicationDbContext context, ILogger<EmployeeController> logger)
        {
            unitOfWork = new UnitOfWork(context);
            _userManager = userManager;

            _logger = logger;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userName = User.FindFirstValue(ClaimTypes.Name);

            //IdentityUser user = await _userManager.GetUserAsync(User);
            //string userEmail = user?.Email;

            //ViewData["Name"] = userId;

            var employee = (IdentityUser)unitOfWork.Employees.SingleOrDefault(x => x.Id == userId);

            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            var employee = unitOfWork.Employees.SingleOrDefault(x => x.Id == Id);

            //Build a dropdown list of all states with assigned values
            var states = new StateService().GetList().ToList();
            ViewBag.Dropdown = (from c in states select new { c.State, c.Value }).Distinct();


            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee, string stateID)
        {
            try
            {
                var check = unitOfWork.Employees.SingleOrDefault(x => x.Id == employee.Id);
                if (check == null)
                {
                    _logger.LogInformation("User does not exist in the database");
                    new RedirectToActionResult("Index", "Home", null);
                }

                if (employee.TFN != null && employee.TFN.Length < 9)
                    ModelState.AddModelError("TfnFailed", "TFN numbers must be 9 digits in length");


                check.Name = employee.Name;
                check.Address = employee.Address;
                check.City = employee.City;
                if (stateID != null)
                {
                    check.State = stateID;

                }
                check.PostCode = employee.PostCode;
                check.TFN = employee.TFN;

                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Edit), employee.Id);
                }


                unitOfWork.Employees.Update(check);
                unitOfWork.Complete();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
