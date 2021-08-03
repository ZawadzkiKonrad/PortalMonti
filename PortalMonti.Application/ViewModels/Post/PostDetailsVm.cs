using PortalMonti.Application.Mapping;
using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Application.ViewModels.Post
{
    public class PostDetailsVm :IMapFrom<Domain.Model.Post>
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Text { get; set; }
        

        public DateTime Date { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Model.Post, PostDetailsVm>();
        }
    }
}
