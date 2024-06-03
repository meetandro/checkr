using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class Card
    {
        public int Id { get; set; }

        [Required]
        public string CardName { get; set; } = "";

        public string CardContent { get; set; } = "";

        public string CardImageFileName { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public DateTime DueDate { get; set; }

        // Foreign Keys

        public int BoxId { get; set; }

        // Collections

        public List<ToDoItem> ToDoItems { get; set; } = [];
    }
}
