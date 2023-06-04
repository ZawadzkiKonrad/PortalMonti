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
using System.IO;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace PortalMonti.Web.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ChatController : Controller
    {
        private IHubContext<ChatHub> _chat;
        private Context _context;
        private IFriendService _friendService;
        private IImageService _imageService;
        private readonly INotyfService _notyf;

        public ChatController(IHubContext<ChatHub> chat, Context context, IFriendService friendService, IImageService imageService,INotyfService notyf)
        {
            _chat = chat;
            _context = context;
            _friendService = friendService;
            _imageService = imageService;
            _notyf = notyf;
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
        public async Task<IActionResult> SendMessage(int chatId, string message, string roomName, string appUserId, IFormFile file,IFormFile image)
        {
           
            string imagePath = string.Empty;
            if (image!=null)
            {

                imagePath = _imageService.UploadFile(image);
               
            };

            string filePath=string.Empty;
            if (file != null)
            {
               filePath = await UploadFile(file);
                
            };

            var msg = new Message
            {
                Image = imagePath,
                File = filePath,
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
                    Timestamp = msg.Timestamp.ToString("dd/MM/yyyy hh:mm:ss"),
                    File = msg.File,
                    Image=msg.Image
                }); ;
           
            

            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendNotification(string appUserId,string authorId,string authorName)
        {   var AuthorUser= _context.Users.FirstOrDefault(x => x.Id == authorId);
            var not = new PortalMonti.Domain.Model.Notification() { Text = "nowa wiadomość",AuthorId=authorId,AuthorName=authorName,AuthorImage=AuthorUser.ImageProfile };
            
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


            return ViewComponent("NotificationsList", noti);

            
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            string path = "";
            string pathEnd = "";
            string filename;
            bool iscopied = false;
            try
            {
                if (file.Length > 0)
                {
                    filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload"));
                    using (var filestream = new FileStream(Path.Combine(path, filename), FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);
                    }
                    iscopied = true;

                    //pathEnd = path + "\\" + filename;
                    pathEnd = filename;
                }
                else
                {
                    iscopied = false;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return pathEnd;
        }
    }
}
