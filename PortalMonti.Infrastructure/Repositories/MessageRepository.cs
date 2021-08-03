using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalMonti.Infrastructure.Repositories
{
   public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;
        public MessageRepository(Context context)
        {
            _context = context;
        }

        public void DeleteMessage (int messageId)
        {
            var message = _context.Posts.Find(messageId);
            if (message!=null)
            {
                _context.Posts.Remove(message);
                _context.SaveChanges();
            }

        }
        public int AddMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message.Id;

        }

        public IQueryable<Message> GetAllMessages()
        {
            var messages = _context.Messages;
            return messages;
        }

        public IQueryable<Domain.Model.Type> GetAllTypes()
        {
            var types = _context.Types;
            return types;
        }

        public void SendMessage()
        { }
    }
}
