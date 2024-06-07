using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class CardRepository(ApplicationDbContext context) : ICardRepository
    {
        private readonly ApplicationDbContext _context = context;

        public List<Card> GetAllCards()
        {
            var cards = _context.Cards
                .Include("ToDoItems")
                .ToList();
            return cards;
        }

        public Card GetCardById(int id)
        {
            var card = _context.Cards
                .Include("ToDoItems")
                .FirstOrDefault(c => c.Id == id);
            return card;
        }

        public Card AddCard(Card card)
        {
            _context.Cards.Add(card);
            _context.SaveChanges();
            return card;
        }

        public Card UpdateCard(Card card)
        {
            _context.Cards.Update(card);
            _context.SaveChanges();
            return card;
        }

        public Card DeleteCard(int id)
        {
            var card = GetCardById(id);
            _context.Cards.Remove(card);
            _context.SaveChanges();
            return card;
        }
    }
}
