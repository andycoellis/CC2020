using System.Collections.Generic;
using CC2020.Data;
using CC2020.Models;
using Microsoft.AspNetCore.Mvc;

namespace CC2020.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController
    {
        private readonly IUnitOfWork unitOfWork;

        public TestController(ApplicationDbContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        [Route("Index")]
        public IEnumerable<Employee> GetAll()
        {
            return unitOfWork.Employees.GetAll();
        }
    }
}
