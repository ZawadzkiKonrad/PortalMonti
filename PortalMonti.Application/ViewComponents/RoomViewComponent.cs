using System.Linq;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PortalMonti.Infrastructure;

namespace ChatApp.ViewComponents
{
    public class RoomViewComponent : ViewComponent
    {
        private Context _context;

        public RoomViewComponent(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //var chats = _context.ChatUsers
            //    .Include(x => x.Chat)
            //    .Where(x => x.UserId == userId
            //        && x.Chat.Type == _context.Room)
            //    .Select(x => x.Chat)
            //    .ToList();

            var chats = _context.Chats.ToList();

            return View(chats);
        }
    }
}