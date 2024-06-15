using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class TagDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Hex { get; set; } = string.Empty;

        public int BoardId { get; set; }
    }
}
