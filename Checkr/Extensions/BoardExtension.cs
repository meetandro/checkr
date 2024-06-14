using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Extensions
{
    public static class BoardExtension
    {
        public static BoardDto ToBoardDto(this Board board)
        {
            return new BoardDto
            {
                Name = board.Name,
                OwnerId = board.OwnerId
            };
        }
    }
}
