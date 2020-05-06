using System;
using System.Collections.Generic;
using CC2020.Models;

namespace CC2020.Services
{
    public class BusinessService
    {
        private PayService _payservice;

        public BusinessService()
        {
            _payservice = new PayService();
        }

        /// <summary>
        /// This function activates a business service that creates an Employees timesheet for a given week
        /// </summary>
        /// <param name="employee">An Employee object</param>
        /// <param name="company">A Company object</param>
        /// <param name="employeeTimesheets">A List of all Timesheets for a given weekly period</param>
        /// <param name="payAgreement">An Employee pay agreement with a given Company</param>
        /// <param name="payYTD">An Employees Pay of the Year to Date of a given financial year</param>
        /// <returns>Weekly Payslip of a given Employees weekly hours worked</returns>
        public WeeklyPayslip EmployeeWeeklyTimeSheet(
                                                    Employee employee, Company company,
                                                    List<Timesheet> employeeTimesheets,
                                                    PayAgreement payAgreement,
                                                    double payYTD
                                                    )
        {
            return _payservice.GetEmpoyeeTimesheet(employee,company, employeeTimesheets, payAgreement, payYTD);
        }
    }
}
