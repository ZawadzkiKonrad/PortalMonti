using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalMonti.Domain.Model
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime When { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Text { get; set; }
        public string UserId { get; set; }
        public virtual AppUser Sender { get; set; }




    }
}
