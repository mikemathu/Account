using System.ComponentModel.DataAnnotations;

namespace Accounts.Dtos.Banks
{
    public class CreateUpdateBankDto
    {
        public int AccountNo { get; set; }
        public string BankCode { get; set; }
        public int BankID { get; set; }
        public string Branch { get; set; }
        public string BranchCode { get; set; }
        public string Name { get; set; }
    }
}
