using System.ComponentModel.DataAnnotations;

namespace Accounts.Models.Banks
{
    public class Bank
    {
        public int AccountNo { get; set; }
        public string BankCode { get; set; }
        [Key]
        public int BankID { get; set; }
        public string Branch { get; set; }
        public string BranchCode { get; set; }
        public int CompanyBranchID { get; set; }
        public string Name { get; set; }
        public string SubAccountID { get; set; }
    }
}
