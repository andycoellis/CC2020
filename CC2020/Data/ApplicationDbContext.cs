using System;
using System.Collections.Generic;
using System.Text;
using CC2020.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CC2020.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PayAgreement> PayAgreements { get; set; }
        public DbSet<Timesheet> Timesheets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Associations [Many to One]

            //Pay Agreements
            builder.Entity<PayAgreement>().HasOne(x => x.Employee).WithMany(x => x.PayAgreements)
                .HasForeignKey(x => x.EmployeeID);

            builder.Entity<PayAgreement>().HasOne(x => x.Company).WithMany(x => x.PayAgreements)
                .HasForeignKey(x => x.CompanyID);


            //Timesheets
            builder.Entity<Timesheet>().HasOne(x => x.Employee).WithMany(x => x.Timesheets)
                .HasForeignKey(x => x.EmployeeID);

            builder.Entity<Timesheet>().HasOne(x => x.Company).WithMany(x => x.Timesheets)
                .HasForeignKey(x => x.CompanyID);
        }
    }
}
