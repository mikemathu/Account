using System.ComponentModel.DataAnnotations;

namespace Accounts.Models
{
    public class Configuration
    {
        [Key]
        public int ConfigurationType { get; set; }
        public string Name { get; set; }
    }
}
