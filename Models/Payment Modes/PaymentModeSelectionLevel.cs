using System.ComponentModel.DataAnnotations;

namespace Accounts.Models.Payment_Modes
{
    public class PaymentModeSelectionLevel
    {
        public string Level { get; set; }
        public int Name { get; set; }
        [Key]
        public int PaymentModeSelectionLevelID { get; set; }
    }
}
