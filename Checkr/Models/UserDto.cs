using Checkr.Entities;
using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class UserDto
    {
        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

    }
}
