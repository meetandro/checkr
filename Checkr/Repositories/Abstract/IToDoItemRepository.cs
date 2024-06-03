using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IToDoItemRepository
    {
        List<ToDoItem> GetAllToDoItems();

        ToDoItem GetToDoItemById(int id);

        ToDoItem AddToDoItem(ToDoItem toDoItem);

        ToDoItem UpdateToDoItem(ToDoItem toDoItem);

        ToDoItem DeleteToDoItem(int id);
    }
}
