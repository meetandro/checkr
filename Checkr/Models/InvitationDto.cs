using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class InvitationDto
    {
        public bool IsAccepted { get; set; }

        public DateTime CreatedAt { get; set; }

        public string SenderId { get; set; } = string.Empty;

        public string RecipientId { get; set; } = string.Empty;

        [Required]
        public string RecipientEmail { get; set; } = string.Empty;

        public int BoardId { get; set; }
    }
}
