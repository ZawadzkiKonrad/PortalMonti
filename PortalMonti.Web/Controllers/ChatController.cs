using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PortalMonti.Application.Interfaces;
using PortalMonti.Domain.Model;
using PortalMonti.Infrastructure;
using PortalMonti.Web.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;

namespace PortalMonti.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChatController : Controller
    {
        private IHubContext<ChatHub> _chat;
        private Context _context;
        private IFriendService _friendService;

        public ChatController(IHubContext<ChatHub> chat, Context context, IFriendService friendService)
        {
            _chat = chat;
            _context = context;
            _friendService = friendService;
        }
        [HttpPost("[action]/{connectionId}/{roomName}")]
        public async Task<IActionResult> JoinRoom(string connectionId, string roomName)
        {
            await _chat.Groups.AddToGroupAsync(connectionId, roomName);

            return Ok();
        }
        [HttpPost("[action]/{connectionId}/{roomName}")]
        public async Task<IActionResult> LeaveRoom(string connectionId, string roomName)
        {
            await _chat.Groups.RemoveFromGroupAsync(connectionId, roomName);

            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> SendMessage(int chatId, string message, string roomName, string appUserId)
        {
            var msg = new Message
            {
                ChatId = chatId,
                Text = message,
                Name = User.Identity.Name,
                Timestamp = DateTime.Now,

            };
            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();

            await _chat.Clients.Group(roomName)
                .SendAsync("RecieveMessage", new
                {      //tworze tu niwy obiekt zeby data nie wariowala parsuje ja na string
                    Text = msg.Text,
                    Name = msg.Name,
                    Timestamp = msg.Timestamp.ToString("dd/MM/yyyy hh:mm:ss")
                });

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendNotification(string appUserId,string authorId,string authorName)
        {
            var not = new Notification() { Text = "nowa wiadomość",AuthorId=authorId,AuthorName=authorName };
            
            var user = _context.Users.FirstOrDefault(x => x.Id == appUserId);
            user.Notifications.Add(not);
            await _context.SaveChangesAsync();

            await _chat.Clients.User(appUserId)
                .SendAsync("RecieveNotification",new {
                Text1= authorName
                });
            return Ok();
        }

        //HttpPost("[action]")]
        [HttpGet]
        public IActionResult SetNotiShowed()
        {
            var user = _friendService.GetCurrentUser();
            //var notitest = user.Notifications;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var noti = _context.Notifications.Where(n => n.AppUserId == userId);
            foreach (var not in noti)
            {
                if (not.Showed == false)
                {
                    not.Showed = true;

                }

            }
            _context.SaveChanges();

            //var path = Request.Headers["referer"].ToString(); //pobieranie aktualnego adresu i przekierowanie do niego
            // return Redirect(path);


            return ViewComponent("Notifications", noti);

            
        }
    }
}
