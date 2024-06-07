
using Checkr.Entities;
using Checkr.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ToDoItem> GetAllToDoItems()
        {
            return _context.ToDoItems.ToList();
        }

        public ToDoItem GetToDoItemById(int id)
        {
            return _context.ToDoItems.Find(id);
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
            var toDoItem = _context.ToDoItems.Find(id);
            if (toDoItem != null)
            {
                _context.ToDoItems.Remove(toDoItem);
                _context.SaveChanges();
            }
            return toDoItem;
        }
    }
}

