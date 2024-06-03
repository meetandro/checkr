using Checkr.Entities;

namespace Checkr.Repositories.Abstract
{
    public interface IMessageRepository
    {
        List<Message> GetAllMessages();

        Message GetMessageById(int id);

        Message AddMessage(Message message);

        Message UpdateMessage(Message message);

        Message DeleteMessage(int id);
    }
}
