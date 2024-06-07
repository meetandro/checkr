using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class BoxDto
    {
        [Required]
        public string BoxName { get; set; } = "";

        // Foreign Keys

        public int BoardId { get; set; }
    }
}
