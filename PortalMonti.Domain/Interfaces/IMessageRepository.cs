using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalMonti.Domain.Interfaces
{
  public  interface IMessageRepository
    {
        void DeleteMessage(int messageId);

        int SendMessage(ReceivedMessage message);


        IQueryable<ReceivedMessage> GetAllMessages();
        IQueryable<ReceivedMessage> GetConveration(string appUserId);
        ReceivedMessage GetMessageById(int id);








    }
}
