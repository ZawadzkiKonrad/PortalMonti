using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Domain.Model
{
    public class Chat
    {
        public Chat()
        {
            Messages = new List<Message>();
            Users = new List<ChatUser>();

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NamePrv { get; set; }
        public ChatType Type { get; set; }

        //public string AppUserId { get; set; }
        //public virtual AppUser AppUser { get; set; }


        public virtual List<Message> Messages { get; set; }
        public ICollection<ChatUser> Users { get; set; }
       
    }
}
