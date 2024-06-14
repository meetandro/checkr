using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class TagDto
    {
        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Hex { get; set; } = "";

        public int BoardId { get; set; }
    }
}
