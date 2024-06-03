using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Label
    {
        public int Id { get; set; }

        [Required]
        public string LabelName { get; set; } = "";

        [Required]
        public string LabelHex { get; set; } = "";

        // Collections

        public List<Box> Boxes { get; set; } = [];
    }
}
