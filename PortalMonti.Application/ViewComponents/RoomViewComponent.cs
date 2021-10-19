using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalMonti.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.ViewComponents
{
   public class RoomViewComponent:ViewComponent
    {
        private Context _context;

        public RoomViewComponent(Context context)
        {
            _context = context;
              
        }
        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chats = _context.ChatUsers
                .Include(x=>x.Chat)
                .Where(x => x.UserId == userId)
                .Select(x=>x.Chat)
                .ToList();
            return View(chats);
        }
    }
}
