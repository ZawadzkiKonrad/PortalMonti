using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Domain.Model
{
    public class Tag
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<PostTag> PostTags { get; set; }
    }
}
