using PortalMonti.Application.Mapping;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   public class FriendDetailsVm:IMapFrom<Friend>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string UserPhoto{ get; set; }

        public byte[] Image { get; set; }
        public string PhoneNumber { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<PortalMonti.Domain.Model.Friend, FriendDetailsVm>();
        }
    }

