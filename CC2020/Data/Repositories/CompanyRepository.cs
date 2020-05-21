using System.Linq;
using CC2020.Data.Repositories.IRepositories;
using CC2020.Models;
using Microsoft.EntityFrameworkCore;

namespace CC2020.Data.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public string getCompanyName(long ABN)
        {
            return Context.Companies.SingleOrDefault(x => x.ABN == ABN).CompanyName;
        }

        public long getCompanyABN(string companyName)
        {
            return Context.Companies.SingleOrDefault(x => x.CompanyName == companyName).ABN;
        }
    }
}
