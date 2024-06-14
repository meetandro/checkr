using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Box
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int BoardId { get; set; }

        public Board Board { get; set; } = default!;

        public ICollection<Tag> Tags { get; set; } = [];

        public ICollection<Card> Cards { get; set; } = [];
    }
}
