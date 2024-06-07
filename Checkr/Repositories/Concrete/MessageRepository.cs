
using Checkr.Entities;
using Checkr.Repositories.Abstract;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Repositories.Concrete
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }

        public Message GetMessageById(int id)
        {
            return _context.Messages.Find(id);
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
            var message = _context.Messages.Find(id);
            if (message != null)
            {
                _context.Messages.Remove(message);
                _context.SaveChanges();
            }
            return message;
        }
    }
}

