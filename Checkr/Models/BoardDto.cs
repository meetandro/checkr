using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class BoardDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string OwnerId { get; set; } = string.Empty;
    }
}
