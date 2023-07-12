using System.ComponentModel.DataAnnotations;

namespace Accounts.Dtos.Payment_Modes
{
    public class CreateUpdatePaymentModeDto
    {
        public int Api { get; set; }
        public string CanBeReceived { get; set; }
        public string IsDefault { get; set; }

        public string PaymentModeName { get; set; }

        public int PaymentModeCategotyID { get; set; }
        public string PaymentModeID { get; set; }
        public int PaymentModeSelectionLevelID { get; set; }
        public int SubAccountID { get; set; }

    }
}
