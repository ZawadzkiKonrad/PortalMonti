using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Friend;
using PortalMonti.Application.ViewModels.Post;
using PortalMonti.Domain.Interfaces;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.Services
{
   public class FriendService : IFriendService

    {
        private readonly IFriendRepository _friendRepo;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        public FriendService(IFriendRepository friendRepo,IMapper mapper, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, IHttpContextAccessor accessor)
        {
            _friendRepo = friendRepo;
            _mapper = mapper;
            _userManager = userManager;
            _accessor = accessor;
        }

        public string AddFriend(string id)
        {
            //var friend =_userManager.FindByIdAsync(id);
            var sameUser = _userManager.Users.FirstOrDefault(u => u.Id == id);
            _friendRepo.AddFriend(sameUser);
            //var user = _userManager.GetUserAsync(_accessor.HttpContext.User);
            //var userr = user.Result;
            //userr.Friends.Add(friend);
            //var id = _friendRepo.AddFriend(friend);
            return id;
        }

        public void DeleteFriend(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Friend>> GetAllFriendAsync()
        {
            throw new NotImplementedException();
            //var user = await _userManager.GetUserAsync(_accessor.HttpContext.User);
            //var list = user.Friend;
            
            //return list;
        }


        public FriendDetailsVm GetFriendById(int id)
        {
            var friend = new Friend();
            friend = _friendRepo.GetFriendById(id);

            var postVm = _mapper.Map<FriendDetailsVm>(friend);

            //var postVm = _mapper.Map<PostDetailsVm>(post).ProjectTo<PostDetailsVm>(_mapper.ConfigurationProvider);

            return postVm;
        }

        public ListFriendForListVm GetAllFriends()
        {
            var friends = _friendRepo.GetAllFriends()
                .ProjectTo<FriendsForListVm>(_mapper.ConfigurationProvider).ToList();
            //friends = friends.ProjectTo<ListFriendForListVm>(_mapper.ConfigurationProvider).ToList();
            
            var postList = new ListFriendForListVm()
            {
                PageSize = 1,
                CurrentPage = 1,
                SearchString = "",
                Friends=friends

            };
            return postList;

            
        }

       
    }

    }
  

