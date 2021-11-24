using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PortalMonti.Application.Interfaces;
using PortalMonti.Domain.Model;
using PortalMonti.Infrastructure;
using PortalMonti.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFriendService _friendService;
        private readonly Context _context;
        private readonly IHttpContextAccessor _accessor;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IFriendService friendService,Context context, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _userManager = userManager;
            _friendService = friendService;
            _context = context;
            _accessor = accessor;
        }
        [HttpGet]
        public IActionResult ListUsers()
        { var users = _userManager.Users;
            ViewBag.Users = users;
            return View(users);
        }
        
      
        public IActionResult Index()
        {
            var friends = _friendService.GetAllFriends();
            ViewBag.friends = friends;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chats = _context.Chats
                .Include(x => x.Users)
                .Include(x=>x.Messages)
                .Where(x => x.Users    //pobieranie czatow do ktorych user NIE JEST podłaczony(z !)
                .Any(y => y.UserId == userId))
                .ToList();
            
            return View(chats);
        }

     
        public IActionResult AddFriend(string id)
        {
            
            _friendService.AddFriend(id);
            return RedirectToAction("Index","Post");

        }
        public IActionResult Privacy()
        {
             
             
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoom(string name)
        {
            var chat = new Chat
            {
                Name = name,
                Type = ChatType.Room
            };
            chat.Users.Add(new ChatUser
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,  //szybsze pobieranie id uzytkownika
                Role = UserRole.Admin
            });
            _context.Chats.Add(chat);
           await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

   // [HttpGet("{id}")]
        [HttpGet]
        public IActionResult Chat (int id)
        {
            var chat = _context.Chats
                .Include(x => x.Messages)
                .FirstOrDefault(x => x.Id == id);             
            return View(chat);
        } 
        [HttpGet]
        public IActionResult ChatPrv (string appUserId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var name = appUserId + userId;
            var name2 = userId+appUserId;

            //ViewBag.UserName = User.Identity.Name;

            ViewBag.User = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            ViewBag.UserToChat = _context.Users.FirstOrDefault(x => x.Id == appUserId);
            var friends = _friendService.GetAllFriends();
            ViewBag.friends = friends;

            var chat = _context.Chats
                .Include(x => x.Messages)
                .FirstOrDefault(x => x.Name == name||x.Name==name2);
            if (chat!=null)
            {
                return View(chat);
            }
            else
            {
                var chat2 =  createChatprv(appUserId);
                return View(chat2);
            }

            //var chat = _context.Chats
            //    .Include(x => x.Messages)
            //    .FirstOrDefault(x => x.Id == id);             
            
        } 

        [HttpGet]
        public async Task<IActionResult> JoinRoom(int id)
        {
            var chatUser = new ChatUser
            {
                ChatId = id,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Role = UserRole.Member
            };
            _context.ChatUsers.Add(chatUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("Chat","Home",new { id = id });
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMessage (int chatId,string message)
        {
            var msg = new Message
            {
                ChatId = chatId,
                Text = message,
                Name = User.Identity.Name,
                Timestamp=DateTime.Now
            };
            _context.Messages.Add(msg);
            await _context.SaveChangesAsync();
            return RedirectToAction("Chat", new { id = chatId });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public Chat createChatprv(string appUserId)
        {
            var name = appUserId + User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chat = new Chat
            {
                NamePrv=name,
                Name = name,
                Type = ChatType.Room
            };
            chat.Users.Add(new ChatUser
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,  //szybsze pobieranie id uzytkownika
                Role = UserRole.Admin
            });
            _context.Chats.Add(chat);
             _context.SaveChanges();
            return chat;
        }

    }
}
