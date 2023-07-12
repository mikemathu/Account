using System.ComponentModel.DataAnnotations;

namespace Accounts.Models.Payment_Modes
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
    }
}
