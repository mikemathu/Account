using System.ComponentModel.DataAnnotations;

namespace Accounts.Models
{
    public class AccountClass
    {
        [Key]
        public int AccountClassID { get; set; }
        public int AccountType { get; set; }
        public string ClassName { get; set; }
    }
}
