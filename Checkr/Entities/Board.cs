using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Board
    {
        public int Id { get; set; }

        [Required]
        public string BoardName { get; set; } = "";

        public int OwnerId { get; set; }

        // Collections

        public List<User> Users { get; set; } = [];

        public List<Message> Messages { get; set; } = [];

        public List<Box> Boxes { get; set; } = [];
    }
}
