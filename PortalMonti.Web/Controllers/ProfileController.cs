using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Friend;
using PortalMonti.Domain.Model;
using PortalMonti.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private Context _context;
        private UserManager<AppUser> _userManager;
        private IHttpContextAccessor _accessor;
        private IPostService _postService;
        private IImageService _imageService;
        private IFriendService _friendService;

        public ProfileController(Context context, UserManager<AppUser> userManager, IHttpContextAccessor accessor,IPostService postService,IImageService imageService,IFriendService friendService)
        {
            _context = context;
            _userManager = userManager;
            _accessor = accessor;
            _postService = postService;
            _imageService = imageService;
            _friendService = friendService;
        }
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            ViewBag.User = user;
            var posts = _postService.GetUserPosts(user.Id).ToList();
            
            var images = _imageService.GetAllImages();
            List<string> imagepath = new List<string>();
            foreach (var image in images)
            {
                imagepath.Add(image.Path);
            }
            
            ViewBag.Posts = posts;
            ViewBag.Count = posts.Count;
            ViewBag.Images = imagepath;
            
            return View();
        }
        [HttpGet]
        public IActionResult ViewProfile(string appUserId)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == appUserId);
            var posts = _postService.GetUserPosts(appUserId).ToList();

            var images = _imageService.GetUserImages(appUserId);
            List<string> imagepath = new List<string>();
            foreach (var image in images)
            {
                imagepath.Add(image.Path);
            }
            ViewBag.Posts = posts;
            ViewBag.Count = posts.Count;
            ViewBag.Images = imagepath;
            return View(user);
        }

        [HttpGet]
        public IActionResult ShowFriends()
        {
            //throw new NotImplementedException();
            //var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            //ViewBag.Count=  _postService.GetUserPosts(user.Id).ToList().Count;

            var friends = _friendService.GetAllFriends();
            if (friends.Count() < 1)                                 //gdy nie ma komengtarzy tworze domyslny
            {
                List<FriendsForListVm> lista = new List<FriendsForListVm>();
                FriendsForListVm frd = new FriendsForListVm()
                {
                    Name = "Brak znajomych!"
                };
                lista.Add(frd);
                lista.AsQueryable();
                return PartialView("_ShowFriendsPartial", lista);
            }
            else
            {
                return PartialView("_ShowFriendsPartial", friends);
            }



        }
    }
}
