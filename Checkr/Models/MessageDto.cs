using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class MessageDto
    {
        [Required]
        public string Content { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; }

        public int BoardId { get; set; }
    }
}
