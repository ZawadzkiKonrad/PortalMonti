using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Domain.Model
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
