using PortalMonti.Application.ViewModels.Friend;
using PortalMonti.Application.ViewModels.Post;
using PortalMonti.Domain.Model;
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
        Task<List<AppUser>> GetAllFriendAsync();
        string AddFriend(AppUser friend);
        FriendDetailsVm GetFriendById(string id);        
        void DeleteFriend(int id);
    }
}
