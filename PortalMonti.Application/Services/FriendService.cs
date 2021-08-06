using AutoMapper;
using AutoMapper.QueryableExtensions;
using PortalMonti.Application.Interfaces;
using PortalMonti.Application.ViewModels.Friend;
using PortalMonti.Application.ViewModels.Post;
using PortalMonti.Domain.Interfaces;
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

        public IEnumerable<FriendsForListVm> GetAllFriends()
        {
            var posts = _friendRepo.GetAllFriends()

                .ProjectTo<FriendsForListVm>(_mapper.ConfigurationProvider);
           
            return posts;
        }
       
        public FriendForListVm GetFriendById(int id)
        {
            throw new NotImplementedException();
        }

       
    }

    }
  

