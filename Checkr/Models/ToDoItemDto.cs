using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class ToDoItemDto
    {
        [Required]
        public string ToDoItemContent { get; set; } = "";

        public bool IsCompleted { get; set; }

        // Foreign Keys

        public int CardId { get; set; }
    }
}
