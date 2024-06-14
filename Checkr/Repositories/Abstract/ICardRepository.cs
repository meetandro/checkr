using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface ICardRepository
    {
        Task<IEnumerable<string>> GetCardImageFileNamesByBoardIdAsync(int boardId);

        Task<IEnumerable<string>> GetCardImageFileNamesByBoxIdAsync(int boxId);

        Task<Card?> GetByIdAsync(int id);

        Task<Card> CreateAsync(Card card);

        Task<Card> UpdateAsync(Card card);

        Task<Card?> DeleteAsync(int id);
    }
}
