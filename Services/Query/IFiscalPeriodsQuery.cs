using Accounts.Models.VM;

namespace Accounts.Services.Query
{
    public interface IFiscalPeriodsQuery
    {

        Task<IEnumerable<FiscalPeriodVM>> GetFiscalPeriods();

        Task<IEnumerable<AccountDetailVM>> GetAccountsDetails();
        Task<IEnumerable<SubAccountDetailVM>> GetSubAccountsDetails();
    }
}
