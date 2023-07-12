using Accounts.Services.Command;
using Accounts.Services.Query;
using Accounts.Dtos;
using Accounts.Dtos.Payment_Modes;
using Accounts.Models;
using Accounts.Models.Payment_Modes;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Accounts.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IMapper _mapper;

        //Queries
        private readonly IAssetManagementQuery _assetManagementQuery;
        private readonly IBankDepositsQuery _bankDepositsQuery;
        private readonly IBankReconciliationQuery _bankReconciliationQuery;
        private readonly IBanksQuery _banksQuery;
        private readonly IBudgetingQuery _budgetingQuery;
        private readonly ICapitationsQuery _capitationsQuery;
        private readonly ICashierShiftsQuery _cashierShiftsQuery;
        private readonly ICashTransfersQuery _cashTransfersQuery;
        private readonly IChequesQuery _chequesQuery;
        private readonly ICurrencyUnitsQuery _currencyUnitsQuery;
        private readonly IFiscalPeriodsQuery _fiscalPeriodsQuery;
        private readonly IGeneralLedgerAccountsQuery _generalLedgerAccountsQuery;
        private readonly IJournalVouchersQuery _journalVouchersQuery;
        private readonly IOpeningBalancesQuery _openingBalancesQuery;
        private readonly IPaymentModesQuery _paymentModesQuery;
        private readonly ISchemeItemsQuery _schemesItemsQuery;
        private readonly ISchemesQuery _schemesQuery;
        private readonly ITaxesQuery _taxesQuery;

        //Commands
        private readonly IAssetManagementCommand _assetManagementCommand;
        private readonly IBankDepositsCommand _bankDepositsCommand;
        private readonly IBankReconciliationCommand _bankReconciliationCommand;
        private readonly IBanksCommand _banksCommand;
        private readonly IBudgetingCommand _budgetingCommand;
        private readonly ICapitationsCommand _capitationsCommand;
        private readonly ICashierShiftsCommand _cashierShiftsCommand;
        private readonly ICashTransfersCommand _cashTransfersCommand;
        private readonly IChequesCommand _chequesCommand;
        private readonly ICurrencyUnitsCommand _currencyUnitsCommand;
        private readonly IFiscalPeriodsCommand _fiscalPeriodsCommands;
        private readonly IGeneralLedgerAccountsCommand _generalLedgerAccountsCommand;
        private readonly IJournalVouchersCommand _journalVouchersCommand;
        private readonly IOpeningBalancesCommand _openingBalancesCommand;
        private readonly IPaymentModesCommand _paymentModesCommand;
        private readonly ISchemesCommand _schemesCommand;
        private readonly ISchemeItemsCommand _schemesItemsCommand;
        private readonly ITaxesCommand _taxesCommand;   
        public AccountsController(
            IMapper mapper,
            //Queries
            IAssetManagementQuery assetManagementQuery,
            IBankDepositsQuery bankDepositsQuery,
            IBankReconciliationQuery bankReconciliationQuery,
            IBanksQuery banksQuery,
            IBudgetingQuery budgetingQuery,
            ICapitationsQuery capitationsQuery,
            ICashierShiftsQuery cashierShiftsQuery,
            ICashTransfersQuery cashTransfersQuery,
            IChequesQuery chequesQuery,
            ICurrencyUnitsQuery currencyUnitsQuery,
            IFiscalPeriodsQuery fiscalPeriodsQuery,
            IGeneralLedgerAccountsQuery generalLedgerAccountsQuery,
            IJournalVouchersQuery journalVouchersQuery,
            IOpeningBalancesQuery openingBalancesQuery,
            IPaymentModesQuery paymentModesQuery,
            ISchemeItemsQuery schemesItemsQuery,
            ISchemesQuery schemesQuery,
            ITaxesQuery taxesQuery,
             //Commands
             IAssetManagementCommand assetManagementCommand,
             IBankDepositsCommand bankDepositsCommand,
             IBankReconciliationCommand bankReconciliationCommand,
             IBanksCommand banksCommand,
             IBudgetingCommand budgetingCommand,
             ICapitationsCommand capitationsCommand,
             ICashierShiftsCommand cashierShiftsCommand,
             ICashTransfersCommand cashTransfersCommand,
             IChequesCommand chequesCommand,
             ICurrencyUnitsCommand currencyUnitsCommand,
             IFiscalPeriodsCommand fiscalPeriodsCommands,
             IGeneralLedgerAccountsCommand generalLedgerAccountsCommand,
             IJournalVouchersCommand journalVouchersCommand,
             IOpeningBalancesCommand openingBalancesCommand,
             IPaymentModesCommand paymentModesCommand,
             ISchemesCommand schemesCommand,
             ISchemeItemsCommand schemesItemsCommand,
             ITaxesCommand taxesCommand)
        {
            _mapper = mapper;
            //Queries
            _assetManagementQuery = assetManagementQuery;
            _bankDepositsQuery = bankDepositsQuery;
            _bankReconciliationQuery = bankReconciliationQuery;
            _banksQuery = banksQuery;
            _budgetingQuery = budgetingQuery;
            _capitationsQuery = capitationsQuery;
            _cashierShiftsQuery = cashierShiftsQuery;
            _cashTransfersQuery = cashTransfersQuery;
            _chequesQuery = chequesQuery;
            _currencyUnitsQuery = currencyUnitsQuery;
            _fiscalPeriodsQuery = fiscalPeriodsQuery;
            _generalLedgerAccountsQuery = generalLedgerAccountsQuery;
            _journalVouchersQuery = journalVouchersQuery;
            _openingBalancesQuery = openingBalancesQuery;
            _paymentModesQuery = paymentModesQuery;
            _schemesItemsQuery = schemesItemsQuery;
            _schemesQuery = schemesQuery;
            _taxesQuery = taxesQuery;
            //Commands
            _assetManagementCommand = assetManagementCommand;
            _bankDepositsCommand = bankDepositsCommand;
            _bankReconciliationCommand = bankReconciliationCommand;
            _banksCommand = banksCommand;
            _budgetingCommand = budgetingCommand;
            _capitationsCommand = capitationsCommand;
            _cashierShiftsCommand = cashierShiftsCommand;
            _cashTransfersCommand = cashTransfersCommand;
            _chequesCommand = chequesCommand;
            _currencyUnitsCommand = currencyUnitsCommand;
            _fiscalPeriodsCommands = fiscalPeriodsCommands;
            _generalLedgerAccountsCommand = generalLedgerAccountsCommand;
            _journalVouchersCommand = journalVouchersCommand;
            _openingBalancesCommand = openingBalancesCommand;
            _paymentModesCommand = paymentModesCommand;
            _schemesCommand = schemesCommand;
            _schemesItemsCommand = schemesItemsCommand;
            _taxesCommand = taxesCommand;
        }

        /// <summary>
        /// Fiscal Periods
        /// </summary>
        /// <returns></returns>

        public IActionResult FiscalPeriods()
        {
            return View();
        }


        /// <summary>
        /// FLedger Accounts
        /// </summary>
        /// <returns></returns>

        public IActionResult GeneralLedgerAccounts()
        {
            return View();
        }

      
        public async Task<JsonResult> GetAllAccounts()
        {
            IEnumerable<AccountDetail> accounts = await _generalLedgerAccountsQuery.GetAllAccounts();
            IEnumerable<ReadAllAccountsDto> readAccountDetailsDto = _mapper.Map<IEnumerable<ReadAllAccountsDto>>(accounts);
            return Json(readAccountDetailsDto);
        }

        [HttpPost]
        public async Task<IActionResult> GetAccountDetails([FromBody] int accountID)
        {             
            AccountDetail accountDetails = await _generalLedgerAccountsQuery.GetAccountDetails(accountID);            
            ReadAccountDetailsDto readAccountDetails = _mapper.Map<ReadAccountDetailsDto>(accountDetails);
            return Json(readAccountDetails);                    

        }
        public async Task<JsonResult> DeleteAccount([FromBody] int accountID) 
        {

            bool IsAccountDeleted = _generalLedgerAccountsCommand.DeleteAccount(accountID);

            if (IsAccountDeleted)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                return Json(new { status = true, responce = "Account deleted successfully." });
            }
            else
            {
                return Json(new { status = false, responce = "Cannot delete the account because it has associated sub-accounts." });
            }
        }
        public async Task<JsonResult> GetAllLedgerAccountsPanelSubAccountsByAccountID([FromBody]int accountID)
        {
            /*if (accountID <= 0)
            {
                return Json(new { message = "Invalid account ID." });
               
            }*/            
            IEnumerable<SubAccountDetail> accountSubAccounts = await _generalLedgerAccountsQuery.GetAllSubAccountsByAccountID(accountID);
            IEnumerable<ReadSubAccountDetailsDto> readAccountDetailsDto = _mapper.Map<IEnumerable<ReadSubAccountDetailsDto>>(accountSubAccounts);
            return Json(readAccountDetailsDto);
        }
        public async Task<IActionResult> GetSubAccountDetails([FromBody] int subAccountID)
        {
            SubAccountDetail subAccountDetails = await _generalLedgerAccountsQuery.GetSubAccountDetails(subAccountID);
            ReadSubAccountDetailsDto readAccountDetails = _mapper.Map<ReadSubAccountDetailsDto>(subAccountDetails);
            return Json(readAccountDetails);
        }
        public IActionResult ActivateSubAccount()
        {
            return View();
        } 
        public IActionResult DeactivateSubAccount()
        {
            return View();
        }
        public async Task<JsonResult> DeleteSubAccount([FromBody] int subAccountID)
        {

            bool IsAccountDeleted = _generalLedgerAccountsCommand.DeleteSubAccount(subAccountID);

            if (IsAccountDeleted)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.OK } );
            }
            else
            {
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.Conflict, responce = "Cannot delete the Sub Account because it has a Balance. Consider Transfering the balance." });
            }
        }
        public async Task<JsonResult> GetActiveCashFlowCategories()
        {

            IEnumerable<CashFlowCategory> cashFlowCategories = await _generalLedgerAccountsQuery.GetActiveCashFlowCategories();
            IEnumerable<ReadCashFlowCategoryDto> readAccountDetailsDto = _mapper.Map<IEnumerable<ReadCashFlowCategoryDto>>(cashFlowCategories);

            return Json(readAccountDetailsDto);
        }
        public async Task<JsonResult> GetAllAccountClasses()
        {
            IEnumerable<AccountClass> accountClasses = await _generalLedgerAccountsQuery.GetAllAccountClasses();
            IEnumerable<ReadAccountClassDto2> readAccountClassDto = _mapper.Map<IEnumerable<ReadAccountClassDto2>>(accountClasses);

            return Json(accountClasses);
        }
        public async Task<IActionResult> GetCashFlowCategoryDetails([FromBody] int cashFlowCategoryID)
        {
            CashFlowCategory cashFlowCategoryDetails = await _generalLedgerAccountsQuery.GetCashFlowCategoryDetails(cashFlowCategoryID);
            ReadCashFlowCategoryDto readCashFlowCategoryDto = _mapper.Map<ReadCashFlowCategoryDto>(cashFlowCategoryDetails);
            return Json(readCashFlowCategoryDto);
        } 
        public async Task<JsonResult> DeleteCashFlowCategory([FromBody] int cashFlowCategoryID)
        {
            /*   _generalLedgerAccountsCommand.DeleteCashFlowCategory(cashFlowCategoryID);
               _generalLedgerAccountsCommand.SaveChanges();
               return Ok();*/


            bool IsAccountDeleted = _generalLedgerAccountsCommand.DeleteCashFlowCategory(cashFlowCategoryID);

            if (IsAccountDeleted)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.OK });
            }
            else
            {
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.Conflict, responce = "Cannot delete the Sub Account because it has a Balance. Consider Transfering the balance." });
            }

        }

        [HttpPost]      
        //public JsonResult CreateUpdateAccount([FromBody] CreateUpdateAccountDto createUpdateAccountDto)
        public async  Task<JsonResult> CreateUpdateAccount([FromBody] CreateUpdateAccountDto createUpdateAccountDto)
        {
            AccountDetail accountModel = _mapper.Map<AccountDetail>(createUpdateAccountDto);

            bool createUpdateAccount = _generalLedgerAccountsCommand.CreateUpdateAccount(accountModel);


            if (createUpdateAccount)
            {
                _generalLedgerAccountsCommand.SaveChanges();

                AccountDetail accountDetails = await _generalLedgerAccountsQuery.GetAccountClassName(accountModel);

                CreateUpdateAccountReadDto readAccountDetailsDto = _mapper.Map<CreateUpdateAccountReadDto>(accountDetails);
               return Json( readAccountDetailsDto );
            }
            else
            {
                return Json(new { status = false, responce = "Could Not Create account" });
            }
        }
        public async Task<JsonResult> CreateAccountClass([FromBody] CreateAccountClassDto createAccountClassDto)
        {
            AccountClass accountClassModel = _mapper.Map<AccountClass>(createAccountClassDto);
            /*_generalLedgerAccountsCommand.CreateAccountClass(accountClassModel);
            _generalLedgerAccountsCommand.SaveChanges();

            ReadAccountClassDto readAccountDetailsDto = _mapper.Map<ReadAccountClassDto>(accountClassModel);
            return Json(readAccountDetailsDto);*/


            ///
            bool createAccountClass = _generalLedgerAccountsCommand.CreateAccountClass(accountClassModel);


            if (createAccountClass)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                ReadAccountClassDto readAccountDetailsDto = _mapper.Map<ReadAccountClassDto>(accountClassModel);
                return Json(new { readAccountDetailsDto, status = true, responce = "Account Created successfully." });
            }
            else
            {
                return Json(new { status = false, responce = "Could Not Create account class" });
            }
        }
        public async Task<JsonResult> CreateUpdateSubAccount([FromBody] CreateUpdateSubAccountDto createUpdateSubAccountDto)
        {
            var subAccountModel = _mapper.Map<SubAccountDetail>(createUpdateSubAccountDto);
     /*       _generalLedgerAccountsCommand.CreateUpdateSubAccount(subAccountModel);
            _generalLedgerAccountsCommand.SaveChanges();

            var readAccountDetailsDto = _mapper.Map<ReadSubAccountDetailsDto>(subAccountModel);
            return Json(readAccountDetailsDto);*/

            //
            bool createUpdateSubAccount = _generalLedgerAccountsCommand.CreateUpdateSubAccount(subAccountModel);


            if (createUpdateSubAccount)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                ReadSubAccountDetailsDto readAccountDetailsDto = _mapper.Map<ReadSubAccountDetailsDto>(subAccountModel);
                return Json(new { readAccountDetailsDto, status = true, responce = "Sub Account Created successfully." });
            }
            else
            {
                return Json(new { status = false, responce = "Could Not Create account class" });
            }
        }
        public IActionResult CreateUpdateCashFlowCategory([FromBody] CreateUpdateCashFlowCategoryDto createUpdateCashFlowCategoryDto)
        {
            var cashFlowCategory = _mapper.Map<CashFlowCategory>(createUpdateCashFlowCategoryDto);
      /*      _generalLedgerAccountsCommand.CreateUpdateCashFlowCategory(cashFlowCategory);
            _generalLedgerAccountsCommand.SaveChanges();

            var readCashFlowCategoryDto = _mapper.Map<ReadCashFlowCategoryDto>(cashFlowCategory);
            return Json(readCashFlowCategoryDto);*/

            //

            bool createUpdateSubAccount = _generalLedgerAccountsCommand.CreateUpdateCashFlowCategory(cashFlowCategory);


            if (createUpdateSubAccount)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                ReadCashFlowCategoryDto readCashFlowCategoryDto = _mapper.Map<ReadCashFlowCategoryDto>(cashFlowCategory);
                return Json(new { readCashFlowCategoryDto, status = true, responce = "Sub Account Created successfully." });
            }
            else
            {
                return Json(new { status = false, responce = "Could Not Create account class" });
            }
        }



        /// <summary>
        /// Payment Modes
        /// </summary>
        /// <returns></returns>
        public IActionResult PaymentModes()
        {
            return View();
        }

        public async Task<IActionResult> GetPaymentModes()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> GetPaymentModeDetails([FromBody] int paymentModeID)
        {
            PaymentMode paymentModelDetails = await _generalLedgerAccountsQuery.GetPaymentModeDetails(paymentModeID);
            ReadPaymentModelDetailsDto readPaymentModelDetailsDto = _mapper.Map<ReadPaymentModelDetailsDto>(paymentModelDetails);
            return Json(readPaymentModelDetailsDto);
        }

        public IActionResult DeletePaymentMode([FromBody] int paymentModeID)
        {

            bool IsPaymentModeDeleted = _generalLedgerAccountsCommand.DeletePaymentMode(paymentModeID);

            if (IsPaymentModeDeleted)
            {
                _generalLedgerAccountsCommand.SaveChanges();
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.OK });
            }
            else
            {
                return Json(new { StatusCode = Response.StatusCode = (int)HttpStatusCode.Conflict, responce = "Cannot delete the Sub Account because it has a Balance. Consider Transfering the balance." });
            }
        }

        public IActionResult GetBankAndCashSubAccounts()
        {
            return View();
        }
        public IActionResult GetAllPaymentModeCategories()
        {
            return View();
        }
        public IActionResult GetPaymentModeSelectionLevels()
        {
            return View();
        }
        public IActionResult GetPaymentModeSelectionLevelsByLevel()
        {
            return View();
        }
        public IActionResult GetPaymentModeSelectionLevelDetails()
        {
            return View();
        }
        public IActionResult DeletePaymentModeSelectionLevel()
        {
            return View();
        }
        public IActionResult GetInnerMostPaymentModeSelectionLevels()
        {
            return View();
        }

        
        /// <summary>
        /// Banks
        /// </summary>
        /// <returns></returns>
        public IActionResult Banks()
        {
            return View();
        }


        /// <summary>
        /// Cashier Shifts
        /// </summary>
        /// <returns></returns>
        public IActionResult CashierShifts()
        {
            return View();
        }

        /// <summary>
        /// Journal Voucher
        /// </summary>
        /// <returns></returns>
        public IActionResult JournalVouchers()
        {
            return View();
        }

        /// <summary>
        /// Taxes
        /// </summary>
        /// <returns></returns>
        public IActionResult Taxes()
        {
            return View();
        }

        public async Task<IActionResult> GetAllVATTypes()
        {
            IEnumerable<AccountDetail> vatTypes = await _taxesQuery.GetAllVATTypes();
            IEnumerable<ReadAllAccountsDto> readAccountDetailsDto = _mapper.Map<IEnumerable<ReadAllAccountsDto>>(vatTypes);
            return Json(readAccountDetailsDto);
        }



        /// <summary>
        /// Cash Transfer
        /// </summary>
        /// <returns></returns>
        public IActionResult CashTransfers()
        {
            return View();
        }

        /// <summary>
        /// Bank Deposits
        /// </summary>
        /// <returns></returns>
        public IActionResult BankDeposits()
        {
            return View();
        }

        /// <summary>
        /// Cheques
        /// </summary>
        /// <returns></returns>
        public IActionResult Cheques()
        {
            return View();
        }

        /// <summary>
        /// Bank Reconciliation
        /// </summary>
        /// <returns></returns>
        public IActionResult BankReconciliation()
        {
            return View();
        }

        /// <summary>
        /// Currency Units
        /// </summary>
        /// <returns></returns>
        public IActionResult CurrencyUnit()
        {
            return View();
        }

        /// <summary>
        /// Asset Management
        /// </summary>
        /// <returns></returns>
        public IActionResult FixedAssetManagement()
        {
            return View();
        }
        /// <summary>
        /// Budgeting
        /// </summary>
        /// <returns></returns>
        public IActionResult Budgeting()
        {
            return View();
        }

        /// <summary>
        /// Capitations
        /// </summary>
        /// <returns></returns>
        public IActionResult Capitations()
        {
            return View();
        }

        /// <summary>
        /// Opening Balances
        /// </summary>
        /// <returns></returns>
        public IActionResult OpeningBalances()
        {
            return View();
        }
       





    }
}
