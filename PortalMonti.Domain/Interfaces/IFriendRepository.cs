using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortalMonti.Domain.Interfaces
{
    public interface IFriendRepository
    {
        void DeleteFriend(int friendId);
       
        string AddFriend(AppUser friend);

        IQueryable<AppUser> GetAllFriends();

        Friend GetFriendById(int friendId);
        
    }
}
