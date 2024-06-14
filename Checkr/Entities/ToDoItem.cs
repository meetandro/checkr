using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public int CardId { get; set; }

        public Card Card { get; set; } = default!;
    }
}
