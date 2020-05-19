using System;
using System.Collections.Generic;
using CC2020.Models;

namespace CC2020.Data.Repositories.IRepositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        string getCompanyName(long ABN);

        long getCompanyABN(string companyName);
    }
}
