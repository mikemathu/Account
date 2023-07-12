namespace Accounts.Dtos.Banks
{
    public class ReadBankDetailsDto
    {
        public int BankID { get; set; }
        public string Name { get; set; }
        public int BankCode { get; set; }
        public int AccountNo { get; set; }
        public string Branch { get; set; }
        public int BranchCode { get; set; }
    }
}
