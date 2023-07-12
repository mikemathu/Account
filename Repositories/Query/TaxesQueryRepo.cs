using Accounts.Services.Query;
using Accounts.Models;

namespace Accounts.Repositories.Query
{
    public class TaxesQueryRepo : ITaxesQuery
    {
        public Task<IEnumerable<AccountDetail>> GetAllVATTypes()
        {
            throw new NotImplementedException();
        }
    }
}
