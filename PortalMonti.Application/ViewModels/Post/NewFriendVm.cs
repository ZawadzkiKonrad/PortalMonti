using AutoMapper;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.ViewModels.Post
{
   public class NewFriendVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }

        public byte[] Image { get; set; }
        public string PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewFriendVm, PortalMonti.Domain.Model.Friend>().ReverseMap();

        }
    }
}
