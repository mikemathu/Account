namespace Accounts.Dtos
{
    public class ReadSubAccountDetailsDto
    {
        public int AccountID { get; set; }
        public int ConfigurationType { get; set; }
        public int CurrentBalance { get; set; }
        public int IsActive { get; set; }
        public int IsLocked { get; set; }
        public string Name { get; set; }
        public int SubAccountID { get; set; }

        //Confirm GetAllLedgerAccountsPanelSubAccountsByAccountID for adding properties above
    }
}
