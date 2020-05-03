using System;
using CC2020.Data.Repositories.IRepositories;
using CC2020.Models;

namespace CC2020.Data.Repositories
{
    public class TimesheetRepository : Repository<Timesheet>, ITimesheetRepository
    {
        public TimesheetRepository(ApplicationDbContext context) : base(context)
        { }

        public ApplicationDbContext TimesheetContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
