using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Domain.Model
{
     public class AppUser: IdentityUser
    {
        public string UserLogin { get; set; }
        public int FriendId { get; set; }
        public int ReceivedMessageId { get; set; }

        public virtual List<Friend> Friends { get; set; } 
        public virtual List<ReceivedMessage> ReceivedMessages { get; set; }

        //public List<AppUser> Friends { get; set; }

        public AppUser()
        {
            Friends = new List<Friend>();
            ReceivedMessages = new List<ReceivedMessage>();
        }
    }
 
}
