using Accounts.Models;

namespace Accounts.Services.Query
{
    public interface ITaxesQuery
    {
        Task<IEnumerable<AccountDetail>> GetAllVATTypes();
    }
}
