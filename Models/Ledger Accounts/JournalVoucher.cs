using System.ComponentModel.DataAnnotations;

namespace Accounts.Models
{
    public class JournalVoucher
    {
        [Key]
        public int JournalVoucherId { get; set; }
        public string SourceReference { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public DateTime TrasnactionDate { get; set; }
        public int Amount { get; set; }
        public string Status { get; set; }
        public string PostedBy { get; set; }
        public int FiscalNo { get; set; }

    }
}
