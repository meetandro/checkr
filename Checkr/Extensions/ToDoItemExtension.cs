using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Extensions
{
    public static class ToDoItemExtension
    {
        public static ToDoItemDto ToToDoItemDto(this ToDoItem toDoItem)
        {
            return new ToDoItemDto
            {
                Content = toDoItem.Content,
                IsCompleted = toDoItem.IsCompleted,
                CardId = toDoItem.CardId
            };
        }
    }
}
