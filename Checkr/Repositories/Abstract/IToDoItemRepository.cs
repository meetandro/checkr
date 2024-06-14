using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IToDoItemRepository
    {
        Task<ToDoItem?> GetByIdAsync(int id);

        Task<ToDoItem> CreateAsync(ToDoItem toDoItem);

        Task<ToDoItem> UpdateAsync(ToDoItem toDoItem);

        Task<ToDoItem?> DeleteAsync(int id);
    }
}
