using Checkr.Entities;
using Checkr.Models;

namespace Checkr.Services.Abstract
{
    public interface IMessageService
    {
        Task<Message> CreateMessageAsync(MessageDto messageDto);
    }
}
