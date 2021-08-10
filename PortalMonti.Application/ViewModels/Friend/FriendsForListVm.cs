using AutoMapper;
using PortalMonti.Application.Mapping;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.ViewModels.Friend
{
    public class FriendsForListVm : IMapFrom<PortalMonti.Domain.Model.Friend>
    {
        public string Login { get; set; }
        public int Id { get; set; }

        public byte[] Image { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap< PortalMonti.Domain.Model.Friend, FriendsForListVm >();
        }
    }
}

