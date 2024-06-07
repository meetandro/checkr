using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class CardService(ICardRepository cardRepository) : ICardService
    {
        private readonly ICardRepository _cardRepository = cardRepository;

        public Card AddCard(Card card)
        {
            return _cardRepository.AddCard(card);
        }

        public Card UpdateCard(int cardId, Card card)
        {
            var cardToUpdate = _cardRepository.GetCardById(cardId);

            cardToUpdate = card;

            return _cardRepository.UpdateCard(cardToUpdate);
        }

        public Card DeleteCard(int cardId)
        {
            var card = _cardRepository.GetCardById(cardId);

            return _cardRepository.DeleteCard(cardId);
        }
    }
}
