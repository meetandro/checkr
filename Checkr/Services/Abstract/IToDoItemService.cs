using Checkr.Entities;

namespace Checkr.Services.Abstract
{
    public interface IToDoItemService
    {
        ToDoItem AddToDoItem(ToDoItem toDoItem, int cardId);

        ToDoItem UpdateToDoItem(int toDoItemId, ToDoItem toDoItem, int cardId);

        ToDoItem DeleteToDoItem(int toDoItemId,  int cardId);
    }
}
