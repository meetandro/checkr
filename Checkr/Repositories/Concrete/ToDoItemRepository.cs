using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;

namespace Checkr.Repositories.Concrete
{
    public class ToDoItemRepository(ApplicationDbContext context) : IToDoItemRepository
    {
        private readonly ApplicationDbContext _context = context;

        public List<ToDoItem> GetAllToDoItems()
        {
            var toDoItems = _context.ToDoItems
                .ToList();
            return toDoItems;
        }

        public ToDoItem GetToDoItemById(int id)
        {
            var toDoItem = _context.ToDoItems
                .FirstOrDefault(t => t.Id == id);
            return toDoItem;
        }

        public ToDoItem AddToDoItem(ToDoItem toDoItem)
        {
            _context.ToDoItems.Add(toDoItem);
            _context.SaveChanges();
            return toDoItem;
        }

        public ToDoItem UpdateToDoItem(ToDoItem toDoItem)
        {
            _context.ToDoItems.Update(toDoItem);
            _context.SaveChanges();
            return toDoItem;
        }

        public ToDoItem DeleteToDoItem(int id)
        {
            var toDoItem = GetToDoItemById(id);
            _context.ToDoItems.Remove(toDoItem);
            _context.SaveChanges();
            return toDoItem;
        }
    }
}
