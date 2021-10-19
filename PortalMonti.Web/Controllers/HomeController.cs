using Microsoft.AspNetCore.Authorization;
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

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IFriendService friendService,Context context)
        {
            _logger = logger;
            _userManager = userManager;
            _friendService = friendService;
            _context = context;
        }
        [HttpGet]
        public IActionResult ListUsers()
        { var users = _userManager.Users;
            ViewBag.Users = users;
            return View(users);
        }
        
      
        public IActionResult Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chats = _context.Chats
                .Include(x => x.Users)
                .Where(x => !x.Users    //pobieranie czatow do ktorych user NIE JEST podłaczony
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

    }
}
