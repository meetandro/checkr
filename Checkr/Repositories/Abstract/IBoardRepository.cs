using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IBoardRepository
    {
        List<Board> GetAllBoards();

        Board GetBoardById(int id);

        Board AddBoard(Board board);

        Board UpdateBoard(Board board);

        Board DeleteBoard(int id);
    }
}
