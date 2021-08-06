using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalMonti.Infrastructure.Repositories
{
    
    public class FriendRepository : IFriendRepository
    {   private readonly Context _context;
        public FriendRepository(Context context)
        {
            _context = context;
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
        public int AddFriend(Friend friend)
        {
            _context.Friends.Add(friend);
            _context.SaveChanges();
            return friend.Id;

        }

        public IQueryable<Friend> GetAllFriends()
        {
            var friends = _context.Friends;
            return friends;
        }
        public Friend GetFriendById(int friendId)
        {
            var friend = _context.Friends.Where(i => i.Id == friendId);
            return (Friend)friend;
        }

        public object GetAllPosts()
        {
            throw new NotImplementedException();
        }
    }
}
