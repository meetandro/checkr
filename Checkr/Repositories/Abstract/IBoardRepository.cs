using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IBoardRepository
    {
        Task<IEnumerable<Board>> GetAllBoardsForUserAsync(string userId);

        Task<Board?> GetByIdAsync(int id);

        Task<Board> CreateAsync(Board board);

        Task<Board> UpdateAsync(Board board);

        Task<Board?> DeleteAsync(int id);
    }
}
