using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class CardDto
    {
        [Required]
        public string CardName { get; set; } = "";

        public string CardContent { get; set; } = "";

        public string CardImageFileName { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public DateTime DueDate { get; set; }

        // Foreign Keys

        public int BoxId { get; set; }
    }
}
