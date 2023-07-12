using System.ComponentModel.DataAnnotations;

namespace Accounts.Models
{
    public class FiscalPeriod
    {
        [Key]
        public int FiscalPeriodId { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int IsActive { get; set; }
        public int IsOpen { get; set; }
    }
}
