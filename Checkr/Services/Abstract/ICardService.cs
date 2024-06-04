using Checkr.Entities;

namespace Checkr.Services.Abstract
{
    public interface ICardService
    {
        Card AddCard(Card card, int boxId);

        Card UpdateCard(int cardId, Card card, int boxId);

        Card DeleteCard(int cardId, int boxId);
    }
}
