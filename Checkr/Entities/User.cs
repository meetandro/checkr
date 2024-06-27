using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class User : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        public ICollection<Invitation> SentInvitations { get; set; } = [];

        public ICollection<Invitation> ReceivedInvitations { get; set; } = [];

        public ICollection<Message> Messages { get; set; } = [];

        public ICollection<Board> Boards { get; set; } = [];
    }
}
