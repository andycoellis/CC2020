﻿using System;
using System.Collections.Generic;
using System.Text;
using CC2020.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CC2020.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<PayAgreement> PayAgreements { get; set; }
        public virtual DbSet<Timesheet> Timesheets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Associations [Many to One]

            //Pay Agreements
            builder.Entity<PayAgreement>().HasOne(x => x.Employee).WithMany(x => x.PayAgreements)
                .HasForeignKey(x => x.EmployeeID);

            builder.Entity<PayAgreement>().HasOne(x => x.Company).WithMany(x => x.PayAgreements)
                .HasForeignKey(x => x.CompanyABN);


            //Timesheets
            builder.Entity<Timesheet>().HasOne(x => x.Employee).WithMany(x => x.Timesheets)
                .HasForeignKey(x => x.EmployeeID);

            builder.Entity<Timesheet>().HasOne(x => x.Company).WithMany(x => x.Timesheets)
                .HasForeignKey(x => x.CompanyABN);

            //Applying Rules for auto incrementing pk entries which arent user defined
            builder.Entity<Timesheet>().Property(x => x.ID).ValueGeneratedOnAdd();

            builder.Entity<PayAgreement>().Property(x => x.ID).ValueGeneratedOnAdd();
        }
    }
}
