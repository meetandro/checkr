using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;


namespace Checkr.Repositories.Concrete
{
    public class BoardRepository(ApplicationDbContext context) : IBoardRepository
    {
        private readonly ApplicationDbContext _context = context;

        public List<Board> GetAllBoardsForUser(string userId)
        {
            var boards = _context.Boards
                .Where(b => b.Users.Any(u => u.Id == userId))
                .Include(b => b.Users)
                .Include(b => b.Messages)
                .Include(b => b.Boxes)
                    .ThenInclude(b => b.Cards)
                .ToList();
            return boards;
        }

        public Board GetBoardById(int id)
        {
            var board = _context.Boards
                .Include(b => b.Users)
                .Include(b => b.Messages)
                .Include(b => b.Boxes)
                    .ThenInclude(b => b.Cards)
                .FirstOrDefault(b => b.Id == id);
            return board;
        }

        public Board AddBoard(Board board)
        {
            _context.Boards.Add(board);
            _context.SaveChanges();
            return board;
        }

        public Board UpdateBoard(Board board)
        {
            _context.Boards.Update(board);
            _context.SaveChanges();
            return board;
        }

        public Board DeleteBoard(int id)
        {
            var board = GetBoardById(id);
            _context.Boards.Remove(board);
            _context.SaveChanges();
            return board;
        }
    }
}
