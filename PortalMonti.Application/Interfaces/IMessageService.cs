using PortalMonti.Application.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.Interfaces
{
    public interface IMessageService
    {
        
        int SendMessage(NewMessageVm message);
        IQueryable<MessageForListVm> GetAllMessages();
        MessageDetailsVm GetMessageById(int id);

    }
}
