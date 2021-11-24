using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Domain.Model
{
   public class Notification
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Showed { get; set; }
        public string AppUserId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
