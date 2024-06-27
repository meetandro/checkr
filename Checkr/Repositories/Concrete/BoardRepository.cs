using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;


namespace Checkr.Repositories.Concrete
{
    public class BoardRepository(ApplicationDbContext context) : IBoardRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Board>> GetAllBoardsForUserAsync(string userId)
        {
            return await _context.Boards
                .Where(b => b.Users.Any(u => u.Id == userId))
                .Include(b => b.Users)
                .Include(b => b.Invitations)
                    .ThenInclude(i => i.Sender)
                .Include(b => b.Invitations)
                    .ThenInclude(i => i.Recipient)
                .Include(b => b.Messages)
                .Include(b => b.Tags)
                .Include(b => b.Boxes)
                    .ThenInclude(b => b.Tags)
                .Include(b => b.Boxes)
                    .ThenInclude(b => b.Cards)
                        .ThenInclude(c => c.ToDoItems)
                .ToListAsync();
        }

        public async Task<Board?> GetByIdAsync(int id)
        {
            return await _context.Boards
                .Include(b => b.Users)
                .Include(b => b.Invitations)
                    .ThenInclude(i => i.Sender)
                .Include(b => b.Invitations)
                    .ThenInclude(i => i.Recipient)
                .Include(b => b.Messages)
                .Include(b => b.Tags)
                .Include(b => b.Boxes)
                    .ThenInclude(b => b.Tags)
                .Include(b => b.Boxes)
                    .ThenInclude(b => b.Cards)
                        .ThenInclude(c => c.ToDoItems)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Board> CreateAsync(Board board)
        {
            await _context.Boards.AddAsync(board);
            await _context.SaveChangesAsync();
            return board;
        }

        public async Task<Board> UpdateAsync(Board board)
        {
            _context.Boards.Update(board);
            await _context.SaveChangesAsync();
            return board;
        }

        public async Task<Board?> DeleteAsync(int id)
        {
            var board = await GetByIdAsync(id);
            if (board is not null)
            {
                _context.Boards.Remove(board);
                await _context.SaveChangesAsync();
            }
            return board;
        }
    }
}
