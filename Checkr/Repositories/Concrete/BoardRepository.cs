using Checkr.Entities;
using Checkr.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class BoardRepository : IBoardRepository
    {
        private readonly ApplicationDbContext _context;

        public BoardRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Board> GetAllBoards()
        {
            return _context.Boards.ToList();
        }

        public Board GetBoardById(int id)
        {
            return _context.Boards.Find(id);
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
            var board = _context.Boards.Find(id);
            if (board != null)
            {
                _context.Boards.Remove(board);
                _context.SaveChanges();
            }
            return board;
        }
    }
}

