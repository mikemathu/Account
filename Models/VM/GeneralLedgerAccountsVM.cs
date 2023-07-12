namespace Accounts.Models.VM
{
    public class AccountDetailVM
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountClass { get; set; }
        public string CashFlow { get; set; }
        public IEnumerable<AccountDetailVM> AccountDetails { get; set; }
        public IEnumerable<SubAccountDetailVM> SubAccountDetails { get; set; }

    }

    public class AccountDetailVMList
    {
        public IEnumerable<AccountDetailVM> AccountDetails { get; set; }
    }
        public class SubAccountDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IsActive { get; set; }
        public int AccountDetailsId { get; set; }
        public int CurrentBalance { get; set; }
    }
}
