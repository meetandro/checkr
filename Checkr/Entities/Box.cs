using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Box
    {
        public int Id { get; set; }

        [Required]
        public string BoxName { get; set; } = "";

        // Foreign Keys

        public int BoardId { get; set; }

        // Collections

        public List<Tag> Tags { get; set; } = [];

        public List<Card> Cards { get; set; } = [];
    }
}
