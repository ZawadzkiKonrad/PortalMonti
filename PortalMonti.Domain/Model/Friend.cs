using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Domain.Model
{
    public class Friend
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string UserLogin{ get; set; }

        public byte[] Image { get; set; }
        public string PhoneNumber{ get; set; }
    }
}
