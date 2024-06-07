using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Extensions
{
    public static class BoxDtoExtension
    {
        public static Box ToBox(this BoxDto boxDto)
        {
            return new Box
            {
                BoxName = boxDto.BoxName,
                BoardId = boxDto.BoardId
            };
        }
    }
}
