using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; } = string.Empty;

        public User User { get; set; } = default!;

        public int BoardId { get; set; }

        public Board Board { get; set; } = default!;
    }
}
