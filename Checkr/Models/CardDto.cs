using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class CardDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public string ImageFileName { get; set; } = string.Empty;

        public IFormFile? ImageFile { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DueDate { get; set; }

        public int BoxId { get; set; }
    }
}
