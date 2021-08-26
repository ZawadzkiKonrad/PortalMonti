using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        public FriendService(IFriendRepository friendRepo,IMapper mapper, UserManager<AppUser> userManager, IHttpContextAccessor accessor)
        {
            _friendRepo = friendRepo;
            _mapper = mapper;
            _userManager = userManager;
            _accessor = accessor;
        }

        public string AddFriend(AppUser friend)
        {
            //var user =  _userManager.GetUserAsync(_accessor.HttpContext.User);
            //var userr = user.Result;
            //userr.Friends.Add(friend);
            var id = _friendRepo.AddFriend(friend);
            return id;
        }

        public void DeleteFriend(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUser>> GetAllFriendAsync()
        {
            
            var user = await _userManager.GetUserAsync(_accessor.HttpContext.User);
            var list = user.Friends.ToList();
            
            return list;
        }


        public FriendDetailsVm GetFriendById(string id)
        {
            var friend = new AppUser();
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
  

