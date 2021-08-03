using PortalMonti.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Application.ViewModels.Post
{
    public class NewPostVm
    {
        public String Name { get; set; }
        public String Text { get; set; }
        public ICollection<PostTag> PostTags { get; set; }

    }
}
