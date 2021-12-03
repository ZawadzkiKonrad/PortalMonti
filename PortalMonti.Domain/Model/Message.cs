using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Domain.Model
{
    public class Message
    {
        public int Id { get; set; }
        //public int Message { get; set; }
        public string Name { get; set; }
        
        public string Text { get; set; }
        public string File { get; set; }
        public string Image { get; set; }
        public DateTime Timestamp { get; set; }

        public int ChatId { get; set; }
        public virtual Chat Chat { get; set; }
    }
}
