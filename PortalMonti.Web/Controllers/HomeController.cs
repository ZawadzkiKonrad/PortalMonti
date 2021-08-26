using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortalMonti.Application.Interfaces;
using PortalMonti.Domain.Model;
using PortalMonti.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFriendService _friendService;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, IFriendService friendService)
        {
            _logger = logger;
            _userManager = userManager;
            _friendService = friendService;
        }
        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
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
        public IActionResult AddFriend(AppUser friend)
        {
            _friendService.AddFriend(friend);
            return RedirectToAction("Index");

        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
