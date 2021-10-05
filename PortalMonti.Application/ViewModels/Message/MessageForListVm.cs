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
     public class MessageForListVm: IMapFrom<ReceivedMessage>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string AppUserId { get; set; }
        public string Selected { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<MessageForListVm, ReceivedMessage>().ReverseMap();

        }
    }
}
