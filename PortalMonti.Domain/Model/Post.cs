﻿using System;
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
        public ICollection <PostTag> PostTags { get; set; }
            


    }
}
