using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMonti.Domain.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }



    }
}
