using Checkr.Entities;
using System.ComponentModel.DataAnnotations;

namespace Checkr.Models
{
    public class BoxDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public int BoardId { get; set; }

        public IEnumerable<Tag> BoardTags { get; set; } = [];

        public IEnumerable<Tag> BoxTags { get; set; } = [];

        public ICollection<int> SelectedTagsIds { get; set; } = [];
    }
}
