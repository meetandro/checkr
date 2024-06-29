using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface ICardService
    {
        Task<Card> GetCardByIdAsync(int cardId);

        Task<Card> CreateCardAsync(CardDto cardDto);

        Task<Card> UpdateCardAsync(int cardId, CardDto cardDto);

        Task<Card> DeleteCardAsync(int cardId);
    }
}
