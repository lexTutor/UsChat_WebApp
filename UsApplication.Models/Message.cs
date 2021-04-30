using System;
using System.Collections.Generic;
using System.Text;

namespace UsApplication.Models
{
    public class Message
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string MessageDetails { get; set; }

        public string UserFromId { get; set; }

        public string  UserToId { get; set; }

        public DateTime TimeCreated { get; set; } = DateTime.Now;

        public virtual User User { get; set; }

    }
}
