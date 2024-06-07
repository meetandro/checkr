using Checkr.Entities;

namespace Checkr.Services.Abstract
{
    public interface IToDoItemService
    {
        ToDoItem AddToDoItem(ToDoItem toDoItem);

        ToDoItem UpdateToDoItem(int toDoItemId, ToDoItem toDoItem);

        ToDoItem DeleteToDoItem(int toDoItemId);
    }
}
