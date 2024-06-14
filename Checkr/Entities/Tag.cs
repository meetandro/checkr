using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Hex { get; set; } = string.Empty;

        public int BoardId { get; set; }

        public Board Board { get; set; } = default!;

        public ICollection<Box> Boxes { get; set; } = [];
    }
}
