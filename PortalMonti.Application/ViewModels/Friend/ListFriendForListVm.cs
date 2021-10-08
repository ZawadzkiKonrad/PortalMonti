using AutoMapper;
using PortalMonti.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.ViewModels.Friend
{
    public class ListFriendForListVm:IMapFrom<PortalMonti.Domain.Model.Friend>
    {
        public List<FriendsForListVm> Friends { get; set; }
        public int? CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public string UserPhoto { get; set; }
        public int Count { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PortalMonti.Domain.Model.Friend, ListFriendForListVm>();
            profile.CreateMap<PortalMonti.Domain.Model.AppUser, ListFriendForListVm>();
        }
    }
}
