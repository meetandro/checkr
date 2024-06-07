using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IBoardRepository
    {
        List<Board> GetAllBoardsForUser(string userId);

        Board GetBoardById(int id);

        Board AddBoard(Board board);

        Board UpdateBoard(Board board);

        Board DeleteBoard(int id);
    }
}
