using PortalMonti.Application.ViewModels.Friend;
using PortalMonti.Application.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.Interfaces
{
   public interface IFriendService
    {
        IEnumerable<FriendsForListVm> GetAllFriends();
        int AddFriend(NewFriendVm friend);
        FriendForListVm GetFriendById(int id);        
        void DeleteFriend(int id);
    }
}
