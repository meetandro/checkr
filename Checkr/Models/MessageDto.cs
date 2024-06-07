using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class MessageDto
    {
        [Required]
        public string MessageContent { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        // Foreign Keys

        public string UserId { get; set; }

        public int BoardId { get; set; }
    }
}
