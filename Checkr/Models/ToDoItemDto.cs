using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class ToDoItemDto
    {
        [Required]
        public string Content { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public int CardId { get; set; }
    }
}
