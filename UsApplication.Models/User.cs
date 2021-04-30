using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace UsApplication.Models
{
    public class User: IdentityUser
    {
        public string  ImageUrl { get; set; }

        public ICollection<Message> Messages { get; set; }

        public ICollection<Connection> Connections { get; set; }
    }
}
