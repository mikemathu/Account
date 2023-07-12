using Accounts.Models;

namespace Accounts.Dtos
{
    public class ReadAccountDetailsDto
    {
        public int AccountClassID{ get; set; }
        public int AccountID { get; set; }
        public int AccountNo { get; set; }
        public int CashFlowCategoryID { get; set; }
        public int ConfigurationType { get; set; }
        public int IsLocked { get; set; }
        public string AccountName { get; set; }
    }
}
