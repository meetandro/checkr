using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> GetAllBoardsForUserAsync(string userId);

        Task<Board> GetBoardByIdAsync(int id);

        Task<Board> CreateBoardAsync(BoardDto boardDto);

        Task<Board> UpdateBoardAsync(int boardId, BoardDto boardDto);

        Task<Board> DeleteBoardAsync(int id);

        Task<Board> RemoveUserFromBoardAsync(int boardId, string userId);
    }
}
