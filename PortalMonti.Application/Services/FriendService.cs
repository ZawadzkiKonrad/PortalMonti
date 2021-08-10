using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        public FriendService(IFriendRepository friendRepo,IMapper mapper)
        {
            _friendRepo = friendRepo;
            _mapper = mapper;
        }

        public int AddFriend(NewFriendVm friend)
        {
            throw new NotImplementedException();
        }

        public void DeleteFriend(int id)
        {
            throw new NotImplementedException();
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
  

