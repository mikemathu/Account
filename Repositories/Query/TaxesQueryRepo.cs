using Account_Module.Services.Query;
using Accounts.Models;

namespace Account_Module.Repositories.Query
{
    public class TaxesQueryRepo : ITaxesQuery
    {
        public Task<IEnumerable<AccountDetail>> GetAllVATTypes()
        {
            throw new NotImplementedException();
        }
    }
}
