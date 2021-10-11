using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalMonti.Application.Interfaces;
using PortalMonti.Domain.Model;
using PortalMonti.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalMonti.Web.Controllers
{
    public class ProfileController : Controller
    {
        private Context _context;
        private UserManager<AppUser> _userManager;
        private IHttpContextAccessor _accessor;
        private IPostService _postService;
        private IImageService _imageService;

        public ProfileController(Context context, UserManager<AppUser> userManager, IHttpContextAccessor accessor,IPostService postService,IImageService imageService)
        {
            _context = context;
            _userManager = userManager;
            _accessor = accessor;
            _postService = postService;
            _imageService = imageService;
        }
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            ViewBag.User = user;
            var posts = _postService.GetUserPosts(user.Id);
            
            var images = _imageService.GetAllImages();
            List<string> imagepath = new List<string>();
            foreach (var image in images)
            {
                imagepath.Add(image.Path);
            }
            
            ViewBag.Posts = posts;
            
            ViewBag.Images = imagepath;
            
            return View();
        }
    }
}
