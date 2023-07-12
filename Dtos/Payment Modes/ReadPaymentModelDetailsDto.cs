using System.ComponentModel.DataAnnotations;

namespace Accounts.Dtos.Payment_Modes
{
    public class ReadPaymentModelDetailsDto
    {
        public string CanBeReceived { get; set; }
        public string IsDefault { get; set; }
        public string PaymentModeName { get; set; }
        public int PaymentModeCategotyID { get; set; }
        public int PaymentID { get; set; }
        public int PaymentModeSelectionLevelID { get; set; }
        public int SubAccountID { get; set; }

    }
}
