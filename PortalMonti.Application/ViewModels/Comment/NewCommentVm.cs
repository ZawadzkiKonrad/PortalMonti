using AutoMapper;
using PortalMonti.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Application.ViewModels.Comment
{
    public class NewCommentVm:IMapFrom<Domain.Model.Comment>
    {
        public int Id { get; set; }
        public string Author{ get; set; }
        public string AuthorId { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }

        public string ProfileImage { get; set; }
        public int PostId { get; set; }
        public virtual Domain.Model.Post Post { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCommentVm, Domain.Model.Comment>().ReverseMap();

        }
    }
}
