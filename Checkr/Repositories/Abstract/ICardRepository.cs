using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface ICardRepository
    {
        List<Card> GetAllCards();

        Card GetCardById(int id);

        Card AddCard(Card card);

        Card UpdateCard(Card card);

        Card DeleteCard(int id);
    }
}
