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
        ListFriendForListVm  GetAllFriends();
        int AddFriend(NewFriendVm friend);
        FriendDetailsVm GetFriendById(int id);        
        void DeleteFriend(int id);
    }
}
