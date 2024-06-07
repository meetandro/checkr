using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class LabelDto
    {
        [Required]
        public string LabelName { get; set; } = "";

        [Required]
        public string LabelHex { get; set; } = "";
    }
}
