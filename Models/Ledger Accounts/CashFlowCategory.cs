using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounts.Models
{
    public class CashFlowCategory
    {
        [Key]
        public int CashFlowCategoryID { get; set; }
        public string Name { get; set; }

        [ForeignKey("AccountTypeID")]
        public AccountType AccountType { get; set; }
        public int AccountTypeID { get; set; }
        public int IsActive { get; set; } 
    }
}
