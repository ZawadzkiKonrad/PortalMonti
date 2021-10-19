using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Hubs
{
    public class ChatHub : Hub
    {
        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}
        //public async Task SendToUser(string user, string receiverConnectionID, string  message)
        //{
        //    await Clients.User(receiverConnectionID).SendAsync("ReceiveMessage", user, message);
        //   // await Clients.Client(receiverConnectionID).SendAsync("ReceiveMessage", user, message);

        //}

        //public string GetUserId() => Context.UserIdentifier;

        public string GetConnectionId() => Context.ConnectionId;

    }
}

