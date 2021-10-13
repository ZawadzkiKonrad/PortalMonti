using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalMonti.Application.Interfaces;
using PortalMonti.Domain.Model;
using PortalMonti.Infrastructure;
using PortalMonti.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            
            
            _logger.LogInformation("Jestem w Home/Index");
            return View();
        }

        //public IActionResult AddFriend(AppUser user)
        //{
            
        //    return View();
        //}
        public IActionResult AddFriend(string id)
        {
            
            _friendService.AddFriend(id);
            return RedirectToAction("Index","Post");

        }
        public IActionResult Privacy()
        {
             
             
            return View();
        }
        public async Task<IActionResult> CreateRoom(string name)
        {
            _context.Chats.Add(new Chat
            {
                Name = name,
                Type=ChatType.Room
            });
           await  _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
