using Checkr.Entities;

namespace Checkr.Services.Abstract
{
    public interface IBoardService
    {
        Board AddBoard(Board board, string userId);

        Board UpdateBoard(int boardId, Board board, string userId);

        Board DeleteBoard(int boardId, string userId);
    }
}
