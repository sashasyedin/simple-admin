using SimpleAdmin.Common.Validation.Abstractions;
using SimpleAdmin.Utils;
using System.ComponentModel.DataAnnotations;

namespace SimpleAdmin.Contracts.Users.DTO
{
    public class UserDto : IValidatable
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public short Age { get; set; }

        public void Validate()
        {
            Assert.GreaterThanZero(Id, nameof(Id));
            Assert.GreaterThanZero(Age, nameof(Age));
        }
    }
}
