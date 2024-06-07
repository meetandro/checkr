using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Services.Context;

namespace Checkr.Repositories.Concrete
{
    public class MessageRepository(ApplicationDbContext context) : IMessageRepository
    {
        private readonly ApplicationDbContext _context = context;

        public List<Message> GetAllMessages()
        {
            var messages = _context.Messages
                .ToList();
            return messages;
        }

        public Message GetMessageById(int id)
        {
            var message = _context.Messages
                .FirstOrDefault(m => m.Id == id);
            return message;
        }

        public Message AddMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }

        public Message UpdateMessage(Message message)
        {
            _context.Messages.Update(message);
            _context.SaveChanges();
            return message;
        }

        public Message DeleteMessage(int id)
        {
            var message = GetMessageById(id);
            _context.Messages.Remove(message);
            _context.SaveChanges();
            return message;
        }
    }
}
