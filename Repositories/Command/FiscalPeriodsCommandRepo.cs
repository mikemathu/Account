using Accounts.Models;
using Accounts.Services.Command;
using Microsoft.EntityFrameworkCore;
using Accounts.Data;

namespace Accounts.Repositories.Command
{
    public class FiscalPeriodsCommandRepo : IFiscalPeriodsCommand
    {
        private readonly ApplicationDbContext _context;

        public FiscalPeriodsCommandRepo(ApplicationDbContext context)
        {
            _context = context;
        }     

        public void AddFiscalPeriod(FiscalPeriod fiscalId)
        {
            if (fiscalId == null)
            {
                throw new ArgumentNullException(nameof(fiscalId));
            }

            _context.GeneralLedger_FiscalPeriods.Add(fiscalId);
            //_context.FiscalPeriods.Add(fiscalId);
        }

        public void AddAccountDetails(AccountDetail accountDetail)
        {
            if (accountDetail == null)
            {
                throw new ArgumentNullException(nameof(accountDetail));
            }

            _context.GeneralLedger_AccountsDetails.Add(accountDetail);
            //_context.AccountsDetails.Add(accountDetail);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
