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

namespace PortalMonti.Application.ViewComponents
{
   public class FriendListViewComponent:ViewComponent

    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        public FriendListViewComponent(Context context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            

            var items2 = await _context.Friends.ToListAsync();

            var list = new List<ViewModels.Friend.FriendsForListVm>();

            foreach (var item in items2)
            {
                var model = new ViewModels.Friend.FriendsForListVm()
                {
                    Id = item.Id,
                    Image = item.Image,
                    Login = item.UserLogin
                };

                list.Add(model);
            }
            return View(list);
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
