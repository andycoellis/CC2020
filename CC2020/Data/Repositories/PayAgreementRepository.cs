using System;
using CC2020.Data.Repositories.IRepositories;
using CC2020.Models;

namespace CC2020.Data.Repositories
{
    public class PayAgreementRepository : Repository<PayAgreement>, IPayAgreementRepository
    {
        public PayAgreementRepository(ApplicationDbContext context) : base(context)
        { }

        public ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
