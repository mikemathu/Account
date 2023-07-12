using Accounts.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounts.Dtos
{
    public class CreateUpdateSubAccountDto
    {
        public int AccountID{ get; set; }
        public int CurrentBalance{ get; set; }
        public string Name{ get; set; }
        public int SubAccountID{ get; set; }
    }
}
