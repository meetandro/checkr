using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class CardDto
    {
        [Required]
        public string Name { get; set; } = "";

        public string Content { get; set; } = "";

        public string ImageFileName { get; set; } = "";

        public IFormFile? ImageFile { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DueDate { get; set; }

        public int BoxId { get; set; }
    }
}
