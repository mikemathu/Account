using Accounts.Models;

namespace Accounts.Dtos
{
    public class CreateUpdateAccountReadDto
    {
        public AccountClass AccountClass { get; set; }
        public int AccountID { get; set; }
        public int AccountNo { get; set; }
        public string AccountName { get; set; }
    }
}
