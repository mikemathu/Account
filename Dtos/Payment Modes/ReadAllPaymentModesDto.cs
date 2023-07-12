using System.ComponentModel.DataAnnotations;

namespace Accounts.Dtos.Payment_Modes
{
    public class ReadAllPaymentModesDto
    {
        public string CanBeReceived { get; set; }
        public string Category { get; set; }
        public string IsDefault { get; set; }
        public string PaymentModeName { get; set; }
        public string SubAcc { get; set; }
    }
}
