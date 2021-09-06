using AutoMapper;
using PortalMonti.Application.Mapping;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.ViewModels.Message
{
   public class MessageDetailsVm:IMapFrom<ReceivedMessage>
    {
        
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }

        public string Receiver { get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MessageDetailsVm, ReceivedMessage>().ReverseMap();

        }
    }
}
