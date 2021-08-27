using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalMonti.Infrastructure;
using PortalMonti.Domain.Model;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using PortalMonti.Application.ViewModels.Friend;
using PortalMonti.Application.Services;
using PortalMonti.Application.Interfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace PortalMonti.Application.ViewComponents
{
   public class FriendListViewComponent:ViewComponent

    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IFriendService _friendService;
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<AppUser> _userManager;

        public FriendListViewComponent(Context context,IMapper mapper, IFriendService friendService, IHttpContextAccessor accessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _friendService = friendService;
            _accessor = accessor;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

           // throw new NotImplementedException();


            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            var posts = _context.Friends.Where(i => i.AppUserId == user.Id).ToList();



            // var friends = await _friendService.GetAllFriendAsync();
            var list2 = new List<FriendsForListVm>();
            foreach (var item in posts)
            {
                var model = new FriendsForListVm()
                {
                    Id = item.Id.ToString(),
                    UserLogin = item.UserLogin,
                    Name=item.Name
                    
                };
                list2.Add(model);
            }
            return View(list2);





            //var items2 = await _context.Friends.ToListAsync();

            //var list = new List<ViewModels.Friend.FriendsForListVm>();

            //foreach (var item in items2)
            //{
            //    var model = new ViewModels.Friend.FriendsForListVm()
            //    {
            //        Id = item.Id,
            //        Image = item.Image,
            //        Login = item.UserLogin
            //    };

            //    list.Add(model);
            //}
            //return View(list);
        }






        //bez automapper:
        //      public async Task<IViewComponentResult> InvokeAsync()
        //{


        //    var items2 = await _context.Friends.ToListAsync();

        //    var list = new List<ViewModels.Friend.FriendsForListVm>();

        //    foreach (var item in items2)
        //    {
        //        var model = new ViewModels.Friend.FriendsForListVm()
        //        {
        //            Id = item.Id,
        //            Image = item.Image,
        //            Login = item.Login
        //        };

        //        list.Add(model);
        //    }
        //    return View(list);
        //}



    }
}
