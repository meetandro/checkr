using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string MessageContent { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        // Foreign Keys

        public string UserId { get; set; }

        public int BoardId { get; set; }
    }
}
