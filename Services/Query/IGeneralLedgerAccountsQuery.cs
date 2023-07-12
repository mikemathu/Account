using Accounts.Models;
using Accounts.Models.Payment_Modes;

namespace Account_Module.Services.Query
{
    public interface IGeneralLedgerAccountsQuery 
    {
        Task<AccountDetail> GetAccountDetails(int accountID);
        Task<IEnumerable<AccountDetail>> GetAllAccounts();
        Task<IEnumerable<CashFlowCategory>> GetActiveCashFlowCategories();
        Task<IEnumerable<AccountClass>> GetAllAccountClasses();
        Task<IEnumerable<SubAccountDetail>> GetAllSubAccountsByAccountID(int accountID);
        Task<SubAccountDetail> GetSubAccountDetails(int subAccountID);
        Task<AccountDetail> GetAccountClassName(AccountDetail accountClassID);
        Task<CashFlowCategory> GetCashFlowCategoryDetails(int cashFlowCategoryID);

        //Banks
        /*    Task<IEnumerable<Bank>> GetAllBanks();
            Task<Bank> GetBankDetails(int accountID);*/
        //Payment Modes
        Task<IEnumerable<PaymentMode>> GetAllPaymentModes();

        Task<PaymentMode> GetPaymentModeDetails(int paymentModeID);
    }
}
