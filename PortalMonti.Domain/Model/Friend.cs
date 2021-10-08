using System;
using System.Collections.Generic;
using System.Text;


namespace PortalMonti.Domain.Model
{
    public class Friend
    {
        public int Id { get; set; }
        public string AuthorId{ get; set; }
        public string UserLogin{ get; set; }
        public string Email{ get; set; }
        public string UserName { get; set; }
        public string UserPhoto { get; set; }

        public byte[] Image { get; set; }
        public string PhoneNumber{ get; set; }
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }


    }
}
