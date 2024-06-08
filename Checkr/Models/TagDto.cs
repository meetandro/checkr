using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class TagDto
    {
        [Required]
        public string TagName { get; set; } = "";

        [Required]
        public string TagHex { get; set; } = "";
    }
}
