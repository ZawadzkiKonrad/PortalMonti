using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PortalMonti.Infrastructure.Repositories
{
    
    public class FriendRepository : IFriendRepository
    {   private readonly Context _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        public FriendRepository(Context context, UserManager<AppUser> userManager, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
            _userManager = userManager;
        }
        public void DeleteFriend(int friendId)
        {
            var friend = _context.Friends.Find(friendId);
            if (friend != null)
            {
                _context.Friends.Remove(friend);
                _context.SaveChanges();
            }

        }
        public string AddFriend(AppUser friend)
        {
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;

            //var sameUser = _userManager.Users.FirstOrDefault(u => u.Id == user);
            var friendss = new Friend()
            {
                //AppUserId = friend.Id,
                UserPhoto=friend.ImageProfile,
                UserLogin = friend.UserLogin,
                AuthorId=friend.Id,
                Email=friend.Email,
                UserName=friend.UserName
                

            };
            
            user.Friends.Add(friendss);
            _context.SaveChanges();
            return friend.Id;

        }

        public IQueryable<Friend> GetAllFriends()
        {
            var user = _userManager.GetUserAsync(_accessor.HttpContext.User).Result;
            
            var friends2 = _context.Friends.Where(i => i.AppUserId == user.Id);

            var friends = user.Friends.AsQueryable();//albo to
            return friends2;
        }
        public Friend GetFriendById(int friendId)
        {
            var friend = _context.Friends.FirstOrDefault(i => i.Id == friendId);
            return friend;
        }

        public void UpdateImage(string path, AppUser user)
        {
            
            foreach (var friend in _context.Friends.Where(p => p.AuthorId == user.Id))
            {
                friend.UserPhoto = path;
            }
            _context.SaveChanges();
        }
    }
}
