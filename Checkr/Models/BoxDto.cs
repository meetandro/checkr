using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class BoxDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public int BoardId { get; set; }
    }
}
