using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface IBoardService
    {
        List<Board> GetAllBoardsForUser(string userId);

        Board GetBoardById(int id);

        Board AddBoard(BoardDto boardDto);

        Board AddUserToBoard(int boardId, string userName);

        Board RemoveUserFromBoard(int boardId, string userId);

        Board UpdateBoard(int boardId, BoardDto boardDto);

        Board DeleteBoard(int id);
    }
}
