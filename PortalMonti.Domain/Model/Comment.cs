using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Domain.Model
{
   public class Comment
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public string ProfileImage { get; set; }
        public string Date { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
