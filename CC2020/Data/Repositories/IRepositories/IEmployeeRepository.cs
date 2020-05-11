using System;
using System.Collections.Generic;
using CC2020.Models;

namespace CC2020.Data.Repositories.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<PayAgreement> GetEmployeePayAgreements(string id);
    }
}
