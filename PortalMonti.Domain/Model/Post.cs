using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Domain.Model
{
    public class Post
    {
        public int Id{ get; set;}
        public string Name { get; set; }
        public string Text { get; set; }
                       
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public ICollection <PostTag> PostTags { get; set; }
        public virtual List<Comment> Comments { get; set; }

        //public List<AppUser> Friends { get; set; }

        public Post()
        {
            Comments = new List<Comment>();
            
        }



    }
}
