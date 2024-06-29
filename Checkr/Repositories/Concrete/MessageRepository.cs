using Checkr.Data;
using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class MessageRepository(ApplicationDbContext context) : IMessageRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Message?> GetByIdAsync(int id)
        {
            return await _context.Messages
                .Include(m => m.User)
                .Include(m => m.Board)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Message> CreateAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<Message> UpdateAsync(Message message)
        {
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<Message?> DeleteAsync(int id)
        {
            var message = await GetByIdAsync(id);
            if (message is not null)
            {
                _context.Messages.Remove(message);
                await _context.SaveChangesAsync();
            }
            return message;
        }
    }
}
