
using Checkr.Entities;
using Checkr.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _context;

        public CardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Card> GetAllCards()
        {
            return _context.Cards.ToList();
        }

        public Card GetCardById(int id)
        {
            return _context.Cards.Find(id);
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
            var card = _context.Cards.Find(id);
            if (card != null)
            {
                _context.Cards.Remove(card);
                _context.SaveChanges();
            }
            return card;
        }
    }
}
