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

        int AddMessage(Message message);


        IQueryable<Message> GetAllMessages();


        IQueryable<Domain.Model.Type> GetAllTypes();


        void SendMessage();
       
    }
}
