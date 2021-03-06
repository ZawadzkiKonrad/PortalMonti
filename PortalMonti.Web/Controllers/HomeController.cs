using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoreLinq;
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
              return View(users);


        }
        [HttpGet]
        public IActionResult SearchUsers(string searchString)
        {
            var users = _userManager.Users.Where(x => x.Email.StartsWith(searchString));
            return PartialView(users);


        }
        
      
        public IActionResult Index()
        {   
            var friends = _friendService.GetAllFriends();
            ViewBag.friends = friends;
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var chats = _context.Chats
                .Where(x => x.Users    //pobieranie czatow do ktorych user  JEST podłaczony
                .Any(y => y.UserId == userId))
                .Include(x => x.Messages)
                .Include(x => x.Users).AsEnumerable();
            

            var UserChats = chats.SelectMany(d => d.Users).ToList();        
            var userzy2 = UserChats.DistinctBy(x => x.Email); //usuwanie powtarzajacych sie rekordow, uzylem dodatkowej biblioteki MoreLINQ
            ViewBag.User = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;                  
            ViewBag.ChatUsers = userzy2.ToList();
            

            List<Message> messages = new List<Message>();
            foreach (var item in chats)
            {

                foreach (var mess in item.Messages)
                {
                    messages.Add(mess);
                }

            }                                     
            if (messages.Count < 1 || messages.Any(x=>x.Name!=user.Email)==false)    //sprawdzenie czy sa wiadomosci od inncyb uzytkownikow, jesli nie to chat z samym soba
            {
              return  RedirectToAction("ChatPrv", new { appUserId = user.Id });
                
            }
            else                                             //wyszukiwanie najnowszej wiadomosci
            {
                var mess2 = messages
                    .Where(x => x.Name != user.UserName)
                    .OrderBy(m => m.Timestamp)
                    .Last();


                var nameMess = mess2.Name;
                var appUserId = _context.Users.FirstOrDefault(x => x.UserName == nameMess).Id;
                var name = appUserId + userId;
                var name2 = userId + appUserId;
                
                   
                ViewBag.UserToChat = _context.Users.FirstOrDefault(x => x.Id == appUserId);


                var chat = _context.Chats           //ustawianie domyslnego chatu na ten z najnowsza wiadomoscia
                    .Include(x => x.Messages)
                    .FirstOrDefault(x => x.Name == name || x.Name == name2);



                if (chat != null)
                {
                    return View("ChatPrv", chat);
                }
                else
                {
                    var chat2 = createChatprv(appUserId);
                    return View("ChatPrv", chat2);
                }
            }
        }
        [HttpGet]
        public IActionResult Notifications()
        {
            var userId  = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            ViewBag.User = user;
            var notis = _context.Notifications.Where(x => x.AppUserId == userId).ToList();
            notis.Reverse();
            return View(notis);

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
        //[HttpPost]
        //public async Task<IActionResult> CreateRoom(string name)
        //{
        //    var chat = new Chat
        //    {
        //        Name = name,
        //        Type = ChatType.Room
        //    };
        //    chat.Users.Add(new ChatUser
        //    {
                
        //        UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,  //szybsze pobieranie id uzytkownika
        //        Role = UserRole.Admin,
        //        Email = user.Email,
        //        ProfileImage = user.ImageProfile
        //    });
        //    _context.Chats.Add(chat);
        //   await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
            
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var name = appUserId + userId;
            var name2 = userId + appUserId;


            var chats = _context.Chats
                .Where(x => x.Users    //pobieranie czatow do ktorych user  JEST podłaczony(dodaje ! jesli chce do NIE POLACZOPMNYCH)
                .Any(y => y.UserId == userId))
                .Include(x => x.Messages)
                .Include(x => x.Users);
           
            var UserChats = chats.SelectMany(d => d.Users).ToList();
            var userzy2 = UserChats.DistinctBy(x => x.Email); //usuwanie powtarzajacych sie rekordow, uzylem dodatkowej biblioteki MoreLINQ

            ViewBag.ChatUsers = userzy2.ToList();



            ViewBag.User = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            ViewBag.UserToChat = _context.Users.FirstOrDefault(x => x.Id == appUserId);
            var friends = _friendService.GetAllFriends();
            ViewBag.friends = friends;

            var chat = _context.Chats
                .Include(x => x.Messages)
                .Include(x=>x.Users)
                .FirstOrDefault(x => x.Name == name||x.Name==name2);

            if (chat != null)
            {

                //if (chat.Users.Count < 2 && chat.Users.Any(x=>x.UserId==userId)==false)
                //{
                //    chat.Users.Add(new ChatUser
                //    {
                //        UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,  //szybsze pobieranie id uzytkownika
                //        Role = UserRole.Admin,
                //        Email = user.Email,
                //        ProfileImage = user.ImageProfile
                //    });
                    
                //    _context.SaveChanges();
                //}
                return View(chat);
            }
            else
            {
                var chat2 = createChatprv(appUserId);
                return View(chat2);
            }
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
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            var appUser = _context.Users.FirstOrDefault(x => x.Id == appUserId);
            
            var name = appUserId + userId;
            var chat = new Chat
            {
                NamePrv=name,
                Name = name,
                Type = ChatType.Room
            };
            chat.Users.Add(new ChatUser
            {
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,  //szybsze pobieranie id uzytkownika
                Role = UserRole.Member,
                Email=user.Email,
                ProfileImage=user.ImageProfile
            }); 
            
            if (appUserId!=userId)  //jesli pisze do siebie, nie dodaje 2 userow tylko 1
            {
            chat.Users.Add(new ChatUser
            {
                UserId = appUserId,  
                Role = UserRole.Member,
                Email=appUser.Email,
                ProfileImage=appUser.ImageProfile
            });
            }
           
            _context.Chats.Add(chat);
             _context.SaveChanges();
            return chat;
        }

    }
}
