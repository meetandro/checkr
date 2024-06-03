using System.ComponentModel.DataAnnotations;

namespace Checkr.Entities
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        public string ToDoItemContent { get; set; } = "";

        public bool IsCompleted { get; set; }

        // Foreign Keys

        public int CardId { get; set; }
    }
}
