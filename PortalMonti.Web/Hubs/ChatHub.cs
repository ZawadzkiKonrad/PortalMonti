using Microsoft.AspNetCore.SignalR;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(Message message) =>
               await Clients.All.SendAsync("receiveMessages", message);

    }
}
