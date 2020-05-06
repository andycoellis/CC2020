using System;
using System.Collections.Generic;
using System.Globalization;
using CC2020.Models;

namespace CC2020.Services
{
    /// <summary>
    /// Documentation of an employess weekly payslip
    /// </summary>
    public readonly struct WeeklyPayslip
    {
        public WeeklyPayslip(
                            Employee employee,
                            Company company,
                            DateTime weekBeginning,
                            double pay,
                            double payYTD,
                            double baseHours,
                            double satHours,
                            double sunHours
                            )
        {
            EmpId = $"{employee.EmployeeID}";
            CompanyName = company.CompanyName;
            CompanyABN = $"{company.ABN}";
            PayPeriod = $"" +
                $"{weekBeginning.ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))} - " +
                $"{weekBeginning.AddDays(7).ToString("d", CultureInfo.CreateSpecificCulture("es-ES"))}";
            Pay = $"{pay:C2}";
            PayYTD = $"{payYTD:C2}";
            Tax = $"{pay * TaxRates.LOW:C2}";
            BaseHours = $"{baseHours}";
            SatHours = $"{satHours}";
            SunHours = $"{sunHours}";
        }

        public string EmpId{ get; }
        public string CompanyName { get; }
        public string CompanyABN { get; }
        public string PayPeriod { get; }
        public string Pay { get; }
        public string PayYTD { get; }
        public string Tax { get; }
        public string BaseHours { get; }
        public string SatHours { get; }
        public string SunHours { get; }


    }

    public class PayService
    {
        ///<summary>Retrieve the employees weekly timesheet</summary>>
        public WeeklyPayslip GetEmpoyeeTimesheet(
                                                Employee employee,
                                                Company company,
                                                List<Timesheet> employeeTimesheets,
                                                PayAgreement payAgreement,
                                                double payYTD
                                                )
        {

            //If timesheets are not of a weekly capacity throw exception
            if(employeeTimesheets.Capacity > 7 || employeeTimesheets.Capacity < 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            //Helper method for calculating hours worked in a day
            Func<Timesheet, double> hoursWorked = x =>  Convert.ToDouble((x.EndTime - x.StartTime) - x.Break);

            var firstDate = employeeTimesheets[0].Date;

            var startOfWeek = firstDate.AddDays(-(int)firstDate.DayOfWeek);

            double baseHours = 0;
            double satHours = 0;
            double sunHours = 0;

            foreach(var ts in employeeTimesheets)
            {
                if(ts.Date.DayOfWeek == DayOfWeek.Saturday)
                {
                    satHours += hoursWorked(ts);
                }
                if (ts.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    sunHours += hoursWorked(ts);
                }
                else
                {
                    baseHours += hoursWorked(ts);
                }
            }

            //Employe pay is calculated as <(week hours) * payrate> + <weekend hours * (payrate * penalties)> 
            var pay = (baseHours * (double)payAgreement.PayRate)+
                      (satHours * ((double)payAgreement.PayRate * payAgreement.SaturdayRate))+
                      (sunHours * ((double)payAgreement.PayRate * payAgreement.SundayRate));

            return new WeeklyPayslip
                (
                employee,
                company,
                startOfWeek,
                pay,
                payYTD,
                baseHours,
                satHours,
                sunHours
                );
        }
    }
}
