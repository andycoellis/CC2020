using System;
using System.Linq;
using CC2020.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CC2020.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var dummy = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (dummy.Companies.Any())
                return;

            dummy.Companies.AddRange(
                new Company
                {
                    ABN = 12903767844,
                    CompanyName = "Square and Compass",
                    Address = "222 Clarendon Street, East Melbourne 3022"
                }
                ,
                new Company
                {
                    ABN = 40907025013,
                    CompanyName = "Barry",
                    Address = "85 High Street, Northcote 3070"
                },
                new Company
                {
                    ABN = 70102471414,
                    CompanyName = "Fifty Acres",
                    Address = "38 Bridge Road, Richmond 3012"
                });

            dummy.Employees.AddRange(
                new Employee
                {
                    EmployeeID = 1234,
                    Name = "Ryan Paul",
                    DOB = new DateTime(1985, 12, 12),
                    TFN = "123456789",
                    Address = "30 View Place",
                    City = "Carlton",
                    State = "QLD",
                    PostCode = "3053"
                },
                new Employee
                {
                    EmployeeID = 1111,
                    Name = "Alex Ng",
                    DOB = new DateTime(1979, 10, 20),
                    TFN = "987654321",
                    Address = "40 Foo Street",
                    City = "Melbourne",
                    State = "VIC",
                    PostCode = "3000"
                },
                new Employee
                {
                    EmployeeID = 4444,
                    Name = "Sarah Harry",
                    DOB = new DateTime(1991, 2, 23),
                    TFN = "473829175",
                    Address = "13 Something",
                    City = "Camberwell",
                    State = "VIC",
                    PostCode = "3052"
                },
                new Employee
                {
                    EmployeeID = 3333,
                    Name = "Lois Straus Claude",
                    DOB = new DateTime(1988, 7, 4),
                    TFN = "123456789",
                    Address = "30 Summer Place",
                    City = "Holding",
                    State = "VIC",
                    PostCode = "3012"
                });

            dummy.PayAgreements.AddRange(
                new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    PayRate = 28,
                    SaturdayRate = 1.5,
                    SundayRate = 1.5,
                    PublicHolidayRate = 2,
                    EmployeeID = 4444,
                    CompanyID = 12903767844
                },
                new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    PayRate = 25,
                    SaturdayRate = 1.3,
                    SundayRate = 1.5,
                    PublicHolidayRate = 1.9,
                    EmployeeID = 4444,
                    CompanyID = 70102471414
                },
                new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    PayRate = 23,
                    SaturdayRate = 1.3,
                    SundayRate = 1.5,
                    PublicHolidayRate = 1.5,
                    EmployeeID = 1111,
                    CompanyID = 70102471414
                },
                new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    PayRate = 22,
                    SaturdayRate = 1.3,
                    SundayRate = 1.5,
                    PublicHolidayRate = 1.5,
                    EmployeeID = 3333,
                    CompanyID = 70102471414
                },
                new PayAgreement
                {
                    DateCreated = DateTime.Now,
                    PayRate = 24,
                    SaturdayRate = 1,
                    SundayRate = 1,
                    PublicHolidayRate = 1.2,
                    EmployeeID = 4444,
                    CompanyID = 40907025013
                });

            dummy.Timesheets.AddRange(
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 17),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(13, 45, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 4444,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 18),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(15, 30, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 4444,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 19),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(16, 0, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 4444,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 23),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(14, 0, 0),
                 Break = new TimeSpan(0, 0, 0),
                 EmployeeID = 4444,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 17),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(13, 45, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 1111,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 18),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(15, 30, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 1111,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 19),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(16, 0, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 1111,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 23),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(14, 0, 0),
                 Break = new TimeSpan(0, 0, 0),
                 EmployeeID = 1111,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 17),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(13, 45, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 3333,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 18),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(15, 30, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 3333,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 19),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(16, 0, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 3333,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 1, 23),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(14, 0, 0),
                 Break = new TimeSpan(0, 0, 0),
                 EmployeeID = 3333,
                 CompanyID = 70102471414
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 2, 17),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(13, 45, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 4444,
                 CompanyID = 40907025013
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 2, 18),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(15, 30, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 4444,
                 CompanyID = 40907025013
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 2, 19),
                 StartTime = new TimeSpan(7, 0, 0),
                 EndTime = new TimeSpan(16, 0, 0),
                 Break = new TimeSpan(0, 30, 0),
                 EmployeeID = 4444,
                 CompanyID = 40907025013
             },
             new Timesheet
             {
                 Date = new DateTime(2020, 2, 23),
                 StartTime = new TimeSpan(6, 30, 0),
                 EndTime = new TimeSpan(14, 0, 0),
                 Break = new TimeSpan(0, 0, 0),
                 EmployeeID = 4444,
                 CompanyID = 40907025013
             });
            dummy.SaveChanges();
        }
    }
}
