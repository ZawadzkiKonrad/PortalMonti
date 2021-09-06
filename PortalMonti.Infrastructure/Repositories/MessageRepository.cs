using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<AppUser> _userManager;
        public MessageRepository(Context context, IHttpContextAccessor accessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _accessor = accessor;
            _userManager = userManager;
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
        public int SendMessage(ReceivedMessage message)
        {
            var user = _userManager.FindByIdAsync(message.Receiver).Result;
            user.ReceivedMessages.Add(message);
            _context.SaveChanges();
            return message.Id;

        }

        public IQueryable<ReceivedMessage> GetAllMessages()
        {
            
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            var messages = _context.ReceivedMessages.Where(i => i.Receiver == user.Id);
           
            return messages;
        }

        public ReceivedMessage GetMessageById(int id)
        {
            var message=_context.ReceivedMessages.FirstOrDefault(p => p.Id == id);
            return message;
        }
    }
}
