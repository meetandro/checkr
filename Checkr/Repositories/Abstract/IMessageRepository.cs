using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IMessageRepository
    {
        Task<Message?> GetByIdAsync(int id);

        Task<Message> CreateAsync(Message message);

        Task<Message> UpdateAsync(Message message);

        Task<Message?> DeleteAsync(int id);
    }
}
