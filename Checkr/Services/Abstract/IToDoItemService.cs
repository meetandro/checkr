using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface IToDoItemService
    {
        Task<ToDoItem> GetToDoItemByIdAsync(int id);

        Task<ToDoItem> CreateToDoItemAsync(ToDoItemDto toDoItemDto);

        Task<ToDoItem> UpdateToDoItemAsync(int toDoItemId, ToDoItemDto toDoItemDto);

        Task<ToDoItem> DeleteToDoItemAsync(int toDoItemId);
    }
}
