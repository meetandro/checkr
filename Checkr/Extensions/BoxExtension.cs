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
                BoxName = box.BoxName,
                BoardId = box.BoardId
            };
        }
    }
}
