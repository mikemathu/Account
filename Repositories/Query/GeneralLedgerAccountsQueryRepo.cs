using Account_Module.Services.Query;
using Accounts.Dtos;
using Accounts.Models;
using Accounts.Models.Banks;
using Accounts.Models.Payment_Modes;
using Accounts.Models.VM;
using Accounts.Services;
using Accounts.Services.Command;
using Npgsql;

namespace Account_Module.Repositories.Query
{
    public class GeneralLedgerAccountsQueryRepo : IGeneralLedgerAccountsQuery
    {
        private const string _accountsTable = "AccountsDetails";
        private IConfiguration _config;
        private NpgsqlConnection _connection;
        public GeneralLedgerAccountsQueryRepo(IConfiguration config)
        {
            _config = config;
        }
        private void OpenConnection()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }



        public async Task<IEnumerable<AccountDetail>> GetAllAccounts()
        {
            OpenConnection();
            List<AccountDetail> accounts = new List<AccountDetail>();
            var commandText = "SELECT A.\"AccountName\", A.\"AccountNo\", A.\"AccountID\", C.\"ClassName\" " +
                              "FROM \"AccountsDetails\" A " +
                              "JOIN \"GeneralLedger_AccountClasses\" C ON A.\"AccountClassID\" = C.\"AccountClassID\"";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        accounts.Add(new AccountDetail
                        {
                            AccountClass = new AccountClass { ClassName = (string)reader["ClassName"] },
                            AccountID = reader.GetInt32(reader.GetOrdinal("AccountID")),
                            AccountNo = reader.GetInt32(reader.GetOrdinal("AccountNo")),
                            AccountName = (string)reader["AccountName"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accounts.Count == 0)
                return null;
            return accounts;
        }

        public async Task<AccountDetail> GetAccountDetails(int accountID)
        {
            OpenConnection();
            AccountDetail accountDetails = null;

            var commandText = $"SELECT \"AccountID\", \"AccountNo\", \"AccountName\", \"AccountClassID\"  " +
                               $"FROM \"AccountsDetails\" " +
                               $"WHERE \"AccountID\" = {accountID} ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        accountDetails = new AccountDetail
                        {
                            //AccountClass = new AccountClass { ClassName = (string)reader["ClassName"] },
                            AccountID = reader.GetInt32(reader.GetOrdinal("AccountID")),
                            AccountNo = reader.GetInt32(reader.GetOrdinal("AccountNo")),
                            AccountName = (string)reader["AccountName"]
                        };
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountDetails == null)
                return null;
            return accountDetails;
        }

        public async Task<IEnumerable<CashFlowCategory>> GetActiveCashFlowCategories()
        {
            OpenConnection();
            List<CashFlowCategory> cashFlowCategories = new List<CashFlowCategory>();
            /*      var commandText = $"SELECT \"CashFlowCategoryID\", \"Name\", \"Type\"  " +
                                     $"FROM \"CashFlowCategories\" " +
                                     $"WHERE \"IsActive\" = 1 ";*/

            var commandText = "SELECT A.\"CashFlowCategoryID\", A.\"Name\", C.\"TypeName\" " +
                           "FROM \"CashFlowCategories\" A " +
                           "JOIN \"AccountTypes\" C ON A.\"AccountTypeID\" = C.\"AccountTypeID\"" +
                            $"WHERE \"IsActive\" = 1 ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        cashFlowCategories.Add(new CashFlowCategory
                        {
                            CashFlowCategoryID = reader.GetInt32(reader.GetOrdinal("CashFlowCategoryID")),
                            Name = (string)reader["Name"],
                            AccountType = new AccountType { TypeName = (string)reader["TypeName"] }
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (cashFlowCategories.Count == 0)
                return null;
            return cashFlowCategories;
        }

        public async Task<IEnumerable<AccountClass>> GetAllAccountClasses()
        {
            OpenConnection();
            List<AccountClass> accountClasses = new List<AccountClass>();
            var commandText = $"SELECT \"AccountClassID\", \"AccountType\", \"ClassName\"  " +
                               $"FROM \"GeneralLedger_AccountClasses\" ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        accountClasses.Add(new AccountClass
                        {
                            AccountClassID = reader.GetInt32(reader.GetOrdinal("AccountClassID")),
                            AccountType = (int)reader["AccountType"],
                            ClassName = (string)reader["ClassName"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountClasses.Count == 0)
                return null;
            return accountClasses;
        }

        public async Task<IEnumerable<SubAccountDetail>> GetAllSubAccountsByAccountID(int accountID)
        {
            OpenConnection();
            List<SubAccountDetail> accountSunAccounts = new List<SubAccountDetail>();
            /*  var commandText = $"SELECT \"AccountID\", \"ConfigurationType\", \"CurrentBalance\"" +
                                  $" \"IsActive\", \"IsLocked\", \"Name\"  " +
                                 $"FROM \"SubAccountsDetails\" " +
                                 $"WHERE \"AccountID\" = {accountID} ";*/
            var commandText = $"SELECT *  " +
                               $"FROM \"SubAccountsDetails\" " +
                               $"WHERE \"AccountID\" = {accountID} ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        accountSunAccounts.Add(new SubAccountDetail
                        {
                            AccountID = (int)reader["AccountID"],
                            ConfigurationType = (int)reader["ConfigurationType"],
                            CurrentBalance = (int)reader["CurrentBalance"],
                            IsActive = (int)reader["IsActive"],
                            IsLocked = (int)reader["IsLocked"],
                            Name = (string)reader["Name"],
                            SubAccountID = (int)reader["SubAccountID"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountSunAccounts.Count == 0)
                return null;
            return accountSunAccounts;
        }

        public async Task<SubAccountDetail> GetSubAccountDetails(int accountID)
        {
            OpenConnection();
            SubAccountDetail accountSubAccounts = null;

            var commandText = $"SELECT *  " +
                               $"FROM \"SubAccountsDetails\" " +
                               $"WHERE \"SubAccountID\" = {accountID} ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        accountSubAccounts = new SubAccountDetail
                        {
                            AccountID = (int)reader["AccountID"],
                            ConfigurationType = (int)reader["ConfigurationType"],
                            CurrentBalance = (int)reader["CurrentBalance"],
                            IsActive = (int)reader["IsActive"],
                            IsLocked = (int)reader["IsLocked"],
                            Name = (string)reader["Name"],
                            SubAccountID = (int)reader["SubAccountID"]
                        };
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountSubAccounts == null)
                return null;
            return accountSubAccounts;
        }

        public async Task<CashFlowCategory> GetCashFlowCategoryDetails(int cashFlowCategoryID)
        {
            OpenConnection();
            CashFlowCategory cashFlowCategoryDetails = null;

            var commandText = $"SELECT *  " +
                               $"FROM \"CashFlowCategories\" " +
                               $"WHERE \"CashFlowCategoryID\" = {cashFlowCategoryID} ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        cashFlowCategoryDetails = new CashFlowCategory
                        {
                            CashFlowCategoryID = (int)reader["CashFlowCategoryID"],
                            Name = (string)reader["Name"],
                            //AccountType = new AccountType { TypeName = (string)reader["TypeName"] }
                        };
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (cashFlowCategoryDetails == null)
                return null;
            return cashFlowCategoryDetails;
        }

        public async Task<AccountDetail> GetAccountClassName(AccountDetail accountClassID)
        {
            OpenConnection();
            AccountDetail accountSubAccounts = null;
            /*          var commandText2 = "SELECT A.\"AccountName\", A.\"AccountNo\", A.\"AccountID\", C.\"ClassName\" " +
                                  "FROM \"AccountsDetails\" A " +
                                  "JOIN \"GeneralLedger_AccountClasses\" C ON A.\"AccountClassID\" = C.\"AccountClassID\"";*/

            var commandText = "SELECT A.\"AccountID\", A.\"AccountNo\", A.\"AccountName\", C.\"ClassName\" " +
                               "FROM \"AccountsDetails\" A " +
                               "JOIN \"GeneralLedger_AccountClasses\" C ON A.\"AccountClassID\" = C.\"AccountClassID\"" +
                                $"WHERE A.\"AccountClassID\" = {accountClassID.AccountClassID}";


            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        accountSubAccounts = new AccountDetail
                        {
                            AccountID = (int)reader["AccountID"],
                            AccountNo = (int)reader["AccountNo"],
                            AccountName = (string)reader["AccountName"],
                            AccountClass = new AccountClass { ClassName = (string)reader["ClassName"] },

                        };
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountSubAccounts == null)
                return null;
            return accountSubAccounts;
        }



        ///Banks
        ///
      /*  public async Task<IEnumerable<Bank>> GetAllBanks()
        {
            OpenConnection();
            List<Bank> bank = new List<Bank>();
            var commandText = "SELECT * " +
                              "FROM \"Banks\" A ";
            return bank;
        }*/
        ////
        ///Payment Modes
        ///
        public async Task<IEnumerable<PaymentMode>> GetAllPaymentModes()
        {
            OpenConnection();
            List<PaymentMode> accounts = new List<PaymentMode>();

            var commandText = $"SELECT * " +
                              $"FROM \"PaymentModes\" ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        /*    bank.Add(new Bank
                            {
                                AccountNo = (int)reader["AccountNo"],
                                BankCode = (string)reader["BankCode"],
                                BankID = (int)reader["BankID"],
                                Branch = (string)reader["Branch"],
                                BranchCode = (string)reader["BranchCode"],
                                CompanyBranchID = (int)reader["CompanyBranchID"],
                                Name = (string)reader["Name"],
                                SubAccountID = (string)reader["AccountName"]*/
                        accounts.Add(new PaymentMode
                        {
                            CanBeReceived = (string)reader["CanBeReceived"],
                            Category = (string)reader["Category"],
                            IsDefault = (string)reader["IsDefault"],
                            PaymentModeName = (string)reader["PaymentModeName"],
                            PaymentID = (int)reader["PaymentID"],
                            SubAcc = (string)reader["AccountName"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            /*   if (bank.Count == 0)
                   return null;
               return bank;*/

            if (accounts.Count == 0)
                return null;
            return accounts;
        }

        public async Task<Bank> GetBankDetails(int bankID)
        {
            OpenConnection();
            Bank bankDetails = null;

            var commandText = $"SELECT \"BankID\", \"Name\", \"BankCode\", \"AccountNo\",  \"Branch\",  \"BranchCode\"  " +
                               $"FROM \"Banks\" " +
                               $"WHERE \"BankID\" = {bankID} ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        bankDetails = new Bank
                        {
                            BankID = (int)reader["BankID"],
                            Name = (string)reader["Name"],
                            BankCode = (string)reader["BankCode"],
                            AccountNo = (int)reader["AccountNo"],
                            Branch = (string)reader["Branch"],
                            BranchCode = (string)reader["BranchCode"]
                        };
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (bankDetails == null)
                return null;
            return bankDetails;

            /* if (accounts.Count == 0)
                 return null;
             return accounts;*/
        }

        public Task<PaymentMode> GetPaymentModeDetails(int paymentModeID)
        {
            throw new NotImplementedException();
        }
    }
}

