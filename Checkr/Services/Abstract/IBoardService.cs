using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface IBoardService
    {
        Task<IEnumerable<Board>> GetAllBoardsForUserAsync(string userId);

        Task<Board> GetBoardByIdAsync(int boardId);

        Task<Board> CreateBoardAsync(BoardDto boardDto);

        Task<Board> UpdateBoardAsync(int boardId, BoardDto boardDto);

        Task<Board> DeleteBoardAsync(int boardId);

        Task<Board> RemoveUserFromBoardAsync(int boardId, string userId);
    }
}
