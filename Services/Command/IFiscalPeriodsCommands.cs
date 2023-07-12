using Accounts.Models;
using Accounts.Models.VM;

namespace Accounts.Services.Command
{
    public interface IFiscalPeriodsCommands
    {
        bool SaveChanges();
        void AddFiscalPeriod(FiscalPeriod fiscalId);
        void AddAccountDetails(AccountDetail accountDetail);
    }
}
