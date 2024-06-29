using Checkr.Data;
using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class CardRepository(ApplicationDbContext context) : ICardRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<string>> GetCardImageFileNamesByBoardIdAsync(int boardId)
        {
            return await _context.Cards
                .Where(c => c.Box.BoardId == boardId && !string.IsNullOrEmpty(c.ImageFileName))
                .Select(c => c.ImageFileName)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetCardImageFileNamesByBoxIdAsync(int boxId)
        {
            return await _context.Cards
                .Where(c => c.BoxId == boxId && !string.IsNullOrEmpty(c.ImageFileName))
                .Select(c => c.ImageFileName)
                .ToListAsync();
        }

        public async Task<Card?> GetByIdAsync(int id)
        {
            return await _context.Cards
                .Include(b => b.Box)
                .Include(c => c.ToDoItems)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Card> CreateAsync(Card card)
        {
            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<Card> UpdateAsync(Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<Card?> DeleteAsync(int id)
        {
            var card = await GetByIdAsync(id);
            if (card is not null)
            {
                _context.Cards.Remove(card);
                await _context.SaveChangesAsync();
            }
            return card;
        }
    }
}
