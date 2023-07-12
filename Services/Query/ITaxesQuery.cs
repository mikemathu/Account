using Accounts.Models;

namespace Account_Module.Services.Query
{
    public interface ITaxesQuery
    {
        Task<IEnumerable<AccountDetail>> GetAllVATTypes();
    }
}
