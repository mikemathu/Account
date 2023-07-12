using System.ComponentModel.DataAnnotations;

namespace Accounts.Models.Payment_Modes
{
    public class PaymentMode
    {
        public string CanBeReceived { get; set; }
        public string Category { get; set; }
        public string IsDefault { get; set; }
        public string PaymentModeName { get; set; }


        [Key]
        public string PaymentModeID { get; set; }
        public string SubAcc { get; set; }

        //
        public int PaymentModeCategotyID { get; set; }
        public int PaymentID { get; set; }
        public int PaymentModeSelectionLevelID { get; set; }
        public int SubAccountID { get; set; }
    }
}
