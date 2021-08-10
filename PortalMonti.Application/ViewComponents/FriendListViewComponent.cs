using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalMonti.Infrastructure;
using PortalMonti.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace PortalMonti.Application.ViewComponents
{
   public class FriendListViewComponent:ViewComponent

    {
        private readonly Context _context;
        public FriendListViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int maxPrority, bool isDone)
        {
            //var items = await GetFriendsAsync(maxPrority, isDone);

            var items2 = await _context.Friends.ToListAsync();

            var list = new List<ViewModels.Friend.FriendsForListVm>();

            foreach (var item in items2)
            {
                var model = new ViewModels.Friend.FriendsForListVm()
                {
                    Id = item.Id,
                    Image = item.Image,
                    Login = item.Login
                };

                list.Add(model);
            }

            return View(list);
        }

        //private Task<IEnumerable<Friend>> GetFriendsAsync(int maxPrority, bool isDone)
        //{
        //    return _context.Friends.ToListAsync();

        //}
    }
}
