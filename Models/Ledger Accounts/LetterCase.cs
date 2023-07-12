using System.ComponentModel.DataAnnotations;

namespace Accounts.Models
{
    public class LetterCase
    {
        [Key]
        public int LetterCaseType { get; set; }
    }
}
