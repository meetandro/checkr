using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class MessageDto
    {
        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int BoardId { get; set; }
    }
}
