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
        IQueryable<FriendsForListVm> GetAllFriends();
        Task<List<Friend>> GetAllFriendAsync();
        string AddFriend(string id);
        FriendDetailsVm GetFriendById(int id);        
        void DeleteFriend(int id);
        AppUser GetCurrentUser();
    }
}
