﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CC2020.Data.Repositories.IRepositories;
using CC2020.Models;

namespace CC2020.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public IEnumerable<PayAgreement> GetEmployeePayAgreements(string id)
        {
            return Context.Employees.Include(x => x.PayAgreements)
                .ThenInclude(x => x.Company)
                .SingleOrDefault(x => x.Id == id).PayAgreements;
        }

        public IEnumerable<Payslip> GetEmployeePaySlips(string id)
        {
            return Context.Employees.Include(x => x.Payslips)
                .ThenInclude(x => x.Company)
                .SingleOrDefault(x => x.Id == id).Payslips;
        }
    }
}
