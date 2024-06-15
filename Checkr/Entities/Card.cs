using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public string ImageFileName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public DateTime DueDate { get; set; }

        public int BoxId { get; set; }

        public Box Box { get; set; } = default!;

        public ICollection<ToDoItem> ToDoItems { get; set; } = [];
    }
}
