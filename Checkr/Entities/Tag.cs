using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string TagName { get; set; } = "";

        [Required]
        public string TagHex { get; set; } = "";

        // Collections

        public List<Box> Boxes { get; set; } = [];
    }
}
