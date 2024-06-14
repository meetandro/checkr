using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class ToDoItemRepository(ApplicationDbContext context) : IToDoItemRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<ToDoItem?> GetByIdAsync(int id)
        {
            return await _context.ToDoItems
                .Include(t => t.Card)
                    .ThenInclude(c => c.Box)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<ToDoItem> CreateAsync(ToDoItem toDoItem)
        {
            await _context.ToDoItems.AddAsync(toDoItem);
            await _context.SaveChangesAsync();
            return toDoItem;
        }

        public async Task<ToDoItem> UpdateAsync(ToDoItem toDoItem)
        {
            _context.ToDoItems.Update(toDoItem);
            await _context.SaveChangesAsync();
            return toDoItem;
        }

        public async Task<ToDoItem?> DeleteAsync(int id)
        {
            var toDoItem = await GetByIdAsync(id);
            if (toDoItem is not null)
            {
                _context.ToDoItems.Remove(toDoItem);
                await _context.SaveChangesAsync();
            }
            return toDoItem;
        }
    }
}
