using Checkr.Entities;
using Checkr.Exceptions;
using Checkr.Models;
using Checkr.Repositories.Abstract;
using Checkr.Services.Abstract;

namespace Checkr.Services.Concrete
{
    public class MessageService(
        IMessageRepository messageRepository,
        IBoardRepository boardRepository,
        IUserService userService) : IMessageService
    {
        private readonly IMessageRepository _messageRepository = messageRepository;
        private readonly IBoardRepository _boardRepository = boardRepository;
        private readonly IUserService _userService = userService;

        public async Task<Message> SendMessageAsync(MessageDto messageDto)
        {
            var message = new Message
            {
                Content = messageDto.Content,
                CreatedAt = DateTime.UtcNow,
                User = await _userService.GetUserByIdAsync(messageDto.UserId),
                Board = await _boardRepository.GetByIdAsync(messageDto.BoardId) ?? throw new EntityNotFoundException()
            };

            return await _messageRepository.CreateAsync(message);
        }
    }
}
