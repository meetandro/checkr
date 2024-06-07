using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Extensions
{
    public static class BoardDtoExtension
    {
        public static Board ToBoard(this BoardDto boardDto)
        {
            return new Board
            {
                BoardName = boardDto.BoardName,
                OwnerId = boardDto.OwnerId
            };
        }
    }
}
