using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Extensions
{
    public static class TagExtension
    {
        public static TagDto ToTagDto(this Tag tag)
        {
            return new TagDto
            {
                Name = tag.Name,
                Hex = tag.Hex,
                BoardId = tag.BoardId
            };
        }
    }
}
