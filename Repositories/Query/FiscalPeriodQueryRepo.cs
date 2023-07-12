using Account_Module.Services.Query;
using Accounts.Models.VM;
using Npgsql;

namespace Account_Module.Repositories.Query
{
    public class FiscalPeriodQueryRepo : IFiscalPeriodsQuery
    {
        private const string _fiscalPeriodsTable = "FiscalPeriods";
        private const string _accountDetailsTable = "AccountsDetails";
        private const string _subAccountDetailsTable = "SubAccountDetails";
        private IConfiguration _config;
        private NpgsqlConnection _connection;
        public FiscalPeriodQueryRepo(IConfiguration config)
        {
            _config = config;
        }
        private void OpenConnection()
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }

        public async Task<IEnumerable<FiscalPeriodVM>> GetFiscalPeriods()
        {
            OpenConnection();
            List<FiscalPeriodVM> fiscalPeriods = new List<FiscalPeriodVM>();

            var commandText = $"SELECT * FROM {_fiscalPeriodsTable} ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        fiscalPeriods.Add(new FiscalPeriodVM
                        {
                            Id = (int)reader["Id"],
                            OpenDate = (DateTime)reader["OpenDate"],
                            CloseDate = (DateTime)reader["CloseDate"],
                            IsActive = (int)reader["IsActive"],
                            IsOpen = (int)reader["IsOpen"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (fiscalPeriods.Count() == 0)
                return null;
            return fiscalPeriods;
        }

        public async Task<IEnumerable<AccountDetailVM>> GetAccountsDetails()
        {
            OpenConnection();
            List<AccountDetailVM> accountDetails = new List<AccountDetailVM>();

            string commandText = $"SELECT * FROM \"{_accountDetailsTable}\" ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        accountDetails.Add(new AccountDetailVM
                        {
                            Id = (int)reader["AccountID"],
                            AccountName = (string)reader["Name"],
                            AccountClass = (string)reader["AccountClassID"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountDetails.Count() == 0)
                return null;
            return accountDetails;
        }

        public async Task<IEnumerable<SubAccountDetailVM>> GetSubAccountsDetails()
        {
            OpenConnection();
            List<SubAccountDetailVM> accountDetails = new List<SubAccountDetailVM>();

            //string commandText = $"SELECT * FROM \"{_subAccountDetailsTable}\" WHERE \"AccountDetailId\" = {id}";
            string commandText = $"SELECT * FROM \"{_subAccountDetailsTable}\" ";
            using (NpgsqlCommand command = new NpgsqlCommand(commandText, _connection))
            {
                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        accountDetails.Add(new SubAccountDetailVM
                        {
                            Id = (int)reader["Id"],
                            Name = (string)reader["Name"],
                            IsActive = (int)reader["IsActive"],
                            AccountDetailsId = (int)reader["AccountDetailId"],
                            CurrentBalance = (int)reader["CurrentBalance"]
                        });
                    }
                    reader.Close();
                }
                _connection.Close();
            }
            if (accountDetails.Count() == 0)
                return null;
            return accountDetails;
        }
    }
}
