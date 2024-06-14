using Checkr.Entities;
using Checkr.Exceptions;
using Checkr.Models;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class ToDoItemService(
        IToDoItemRepository toDoItemRepository,
        ICardRepository cardRepository) : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository = toDoItemRepository;
        private readonly ICardRepository _cardRepository = cardRepository;

        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            return await _toDoItemRepository.GetByIdAsync(id) ?? throw new EntityNotFoundException();
        }

        public async Task<ToDoItem> CreateToDoItemAsync(ToDoItemDto toDoItemDto)
        {
            var toDoItem = new ToDoItem
            {
                Content = toDoItemDto.Content,
                IsCompleted = toDoItemDto.IsCompleted,
                Card = await _cardRepository.GetByIdAsync(toDoItemDto.CardId) ?? throw new EntityNotFoundException()
            };

            return await _toDoItemRepository.CreateAsync(toDoItem);
        }

        public async Task<ToDoItem> UpdateToDoItemAsync(int toDoItemId, ToDoItemDto toDoItemDto)
        {
            var toDoItem = await _toDoItemRepository.GetByIdAsync(toDoItemId) ?? throw new EntityNotFoundException();

            toDoItem.Content = toDoItemDto.Content;
            toDoItem.IsCompleted = toDoItemDto.IsCompleted;

            return await _toDoItemRepository.UpdateAsync(toDoItem);
        }

        public async Task<ToDoItem> DeleteToDoItemAsync(int toDoItemId)
        {
            return await _toDoItemRepository.DeleteAsync(toDoItemId) ?? throw new EntityNotFoundException();
        }
    }
}
