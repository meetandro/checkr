using Checkr.Entities;

namespace Checkr.Services.Abstract
{
    public interface ICardService
    {
        Card AddCard(Card card);

        Card UpdateCard(int cardId, Card card);

        Card DeleteCard(int cardId);
    }
}
