using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalMonti.Domain.Model
{
   public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string AppUserId { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public virtual AppUser AppUser { get; set; }
        
    }
}
