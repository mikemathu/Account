using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounts.Models
{
    public class SubAccountDetail
    {
        [Key]
        public int SubAccountID { get; set; }

        [ForeignKey("AccountID")]
        public AccountDetail AccountDetail { get; set; }
        public int AccountID { get; set; }

        [ForeignKey("ConfigurationType")]
        public Configuration Configuration { get; set; }
        public int ConfigurationType { get; set; }
        public int CurrentBalance { get; set; }
        public int IsActive { get; set; }
        public int IsLocked { get; set; }
        public string Name { get; set; }


    }
}
