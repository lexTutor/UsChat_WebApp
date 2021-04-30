using System;
using System.Collections.Generic;
using System.Text;

namespace UsApplication.DTOs
{
    public class ReturnMessageDTO
    {
        public string Id { get; set; }
        public string MessageDetails { get; set; }

        public string UserFromId { get; set; }

        public string UserToId { get; set; }

        public DateTime TimeCreated { get; set; } = DateTime.Now;
    }
}
