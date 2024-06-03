using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = "";

        [Required]
        public string LastName { get; set; } = "";

        // Collections

        public List<Message> Messages { get; set; } = [];

        public List<Board> Boards { get; set; } = [];
    }
}
