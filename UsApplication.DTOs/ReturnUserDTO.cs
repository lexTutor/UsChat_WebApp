using System;
using System.Collections.Generic;
using System.Text;

namespace UsApplication.DTOs
{
    public class ReturnUserDTO
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public ICollection<ReturnConnectionDTO> Connections {get; set;}
    }
}
