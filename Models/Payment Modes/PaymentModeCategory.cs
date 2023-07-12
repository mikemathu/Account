using System.ComponentModel.DataAnnotations;

namespace Accounts.Models.Payment_Modes
{
    public class PaymentModeCategory
    {
        public string PaymentModeCategotyName { get; set; }
        [Key]
        public int PaymentModeCategotyID { get; set; }
    }

}
