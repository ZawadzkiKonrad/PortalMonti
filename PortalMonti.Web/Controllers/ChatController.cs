using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PortalMonti.Domain.Model;
using PortalMonti.Infrastructure;
using PortalMonti.Web.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChatController : Controller
    {
        private IHubContext<ChatHub> _chat;
        private Context _context;

        public ChatController(IHubContext<ChatHub> chat,Context context)
        {
            _chat = chat;
            _context = context;
        }
        [HttpPost("[action]/{connectionId}/{roomName}")]
        public async Task<IActionResult> JoinRoom( string connectionId,string roomName)
        {
            await _chat.Groups.AddToGroupAsync(connectionId,roomName);

            return Ok();
        }
        [HttpPost("[action]/{connectionId}/{roomName}")]
        public async Task<IActionResult> LeaveRoom( string connectionId,string roomName)
        {
            await _chat.Groups.RemoveFromGroupAsync(connectionId,roomName);

            return Ok();
        }
        [HttpPost("[action]")]
        public  async Task<IActionResult> SendMessage(
            int chatId,
            string message,
            string roomName,
            [FromServices]Context ctx)
        {
            var msg = new Message
            {
                ChatId = chatId,
                Text = message,
                Name = User.Identity.Name,
                Timestamp = DateTime.Now,
                
            };
            ctx.Messages.Add(msg);
            await ctx.SaveChangesAsync();

            await _chat.Clients.Group(roomName)
                .SendAsync("RecieveMessage",new {      //tworze tu niwy obiekt zeby data nie wariowala parsuje ja na string
                    Text=msg.Text,
                    Name=msg.Name,
                    Timestamp=msg.Timestamp.ToString("dd/MM/yyyy hh:mm:ss")
                });
            return Ok();
        }
    }
}
