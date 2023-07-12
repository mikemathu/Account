using Accounts.Models.VM;

namespace Account_Module.Services.Query
{
    public interface IFiscalPeriodsQuery
    {

        Task<IEnumerable<FiscalPeriodVM>> GetFiscalPeriods();

        Task<IEnumerable<AccountDetailVM>> GetAccountsDetails();
        Task<IEnumerable<SubAccountDetailVM>> GetSubAccountsDetails();
    }
}
