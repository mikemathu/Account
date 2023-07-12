using System.ComponentModel.DataAnnotations;

namespace Accounts.Models
{
    public class AccountType
    {
        [Key]
        public int AccountTypeID { get; set; }
        public string TypeName { get; set; }
    }
}
