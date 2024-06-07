using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class ToDoItemService(IToDoItemRepository toDoItemRepository) : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository = toDoItemRepository;

        public ToDoItem AddToDoItem(ToDoItem toDoItem)
        {
            return _toDoItemRepository.AddToDoItem(toDoItem);
        }

        public ToDoItem UpdateToDoItem(int toDoItemId, ToDoItem toDoItem)
        {
            var toDoItemToUpdate = _toDoItemRepository.GetToDoItemById(toDoItemId);

            toDoItemToUpdate = toDoItem;

            return _toDoItemRepository.UpdateToDoItem(toDoItemToUpdate);
        }

        public ToDoItem DeleteToDoItem(int toDoItemId)
        {
            return _toDoItemRepository.DeleteToDoItem(toDoItemId);
        }
    }
}
