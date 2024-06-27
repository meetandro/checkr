using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Extensions
{
    public static class BoxExtension
    {
        public static BoxDto ToBoxDto(this Box box)
        {
            return new BoxDto
            {
                Name = box.Name,
                BoardId = box.BoardId,
                BoxTags = box.Tags,
                BoardTags = box.Board.Tags
            };
        }
    }
}
