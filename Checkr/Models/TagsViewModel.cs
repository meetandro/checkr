using Checkr.Entities;

namespace Checkr.Models
{
    public class TagsViewModel
    {
        public int BoxId { get; set; }

        public IEnumerable<Tag> BoardTags { get; set; } = [];

        public IEnumerable<Tag> BoxTags { get; set; } = [];

        public ICollection<int> SelectedTagsIds { get; set; } = [];
    }
}
