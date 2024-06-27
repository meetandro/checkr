using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Board
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string OwnerId { get; set; } = string.Empty;

        public ICollection<User> Users { get; set; } = [];

        public ICollection<Invitation> Invitations { get; set; } = [];

        public ICollection<Message> Messages { get; set; } = [];

        public ICollection<Box> Boxes { get; set; } = [];

        public ICollection<Tag> Tags { get; set; } = [];
    }
}
