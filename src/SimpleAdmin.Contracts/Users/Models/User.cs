using SimpleAdmin.Utils;
using System.ComponentModel.DataAnnotations;

namespace SimpleAdmin.Contracts.Users.Models
{
    public class User
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public short Age { get; set; }
    }
}
