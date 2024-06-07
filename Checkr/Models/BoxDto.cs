using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class BoxDto
    {
        [Required]
        public string BoxName { get; set; } = "";

        public int BoardId { get; set; }
    }
}
