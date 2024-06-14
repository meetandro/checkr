using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class BoxRepository(ApplicationDbContext context) : IBoxRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Box?> GetByIdAsync(int id)
        {
            return await _context.Boxes
                .Include(b => b.Board)
                .Include(b => b.Tags)
                .Include(b => b.Cards)
                    .ThenInclude(c => c.ToDoItems)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Box> CreateAsync(Box box)
        {
            await _context.Boxes.AddAsync(box);
            await _context.SaveChangesAsync();
            return box;
        }

        public async Task<Box> UpdateAsync(Box box)
        {
            _context.Boxes.Update(box);
            await _context.SaveChangesAsync();
            return box;
        }

        public async Task<Box?> DeleteAsync(int id)
        {
            var box = await GetByIdAsync(id);
            if (box is not null)
            {
                _context.Boxes.Remove(box);
                await _context.SaveChangesAsync();
            }
            return box;
        }
    }
}
