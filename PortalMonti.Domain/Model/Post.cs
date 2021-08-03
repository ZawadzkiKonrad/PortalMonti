using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Domain.Model
{
    public class Post
    {
        public int Id{ get; set;}
        public String Name { get; set; }
        public String Text { get; set; }
                       
        public DateTime Date { get; set; }
        public ICollection <PostTag> PostTags { get; set; }
            


    }
}
