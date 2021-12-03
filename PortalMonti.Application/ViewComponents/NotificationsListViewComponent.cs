using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalMonti.Application.Interfaces;
using PortalMonti.Domain.Model;
using PortalMonti.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.ViewComponents
{
    public class NotificationsListViewComponent : ViewComponent
    {
        private readonly Context _context;
        private readonly IFriendService _friendService;

        public NotificationsListViewComponent(Context context, IFriendService friendService)
        {
            _context = context;
            _friendService = friendService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = _friendService.GetCurrentUser();
            var noti = _context.Notifications.Where(n => n.AppUserId == user.Id).AsEnumerable().TakeLast(5).Reverse();

            return View(noti);
        }
    }
}
