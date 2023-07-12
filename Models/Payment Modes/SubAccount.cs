using System.ComponentModel.DataAnnotations;

namespace Accounts.Models.Payment_Modes
{
    public class SubAccount
    {
        public int AccountID { get; set; }
        public int ConfigyrationType { get; set; }
        public int CurrentBalance { get; set; }
        public int IsActive { get; set; }
        public int IsLocked { get; set; }
        public string SubAccountName { get; set; }
        [Key]
        public int SubAccountID { get; set; }
    }
}
