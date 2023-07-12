using Accounts.Models;

namespace Accounts.Dtos
{
    public class ReadCashFlowCategoryDto
    {
        public int CashFlowCategoryID { get; set; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
    }
}
