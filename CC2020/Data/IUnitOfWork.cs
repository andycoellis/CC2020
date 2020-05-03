using System;
using CC2020.Data.Repositories.IRepositories;

namespace CC2020.Data
{
    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        IEmployeeRepository Employees { get; }
        IPayAgreementRepository PayAgreements { get; }
        ITimesheetRepository Timesheets { get; }
        int Complete();
    }
}
