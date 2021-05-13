using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsApplication.DTOs
{
    public class ReceiveMessageDTO
    {
        [Required]
        public string MessageDetails { get; set; }

        public string userToId { get; set; }
        public string userFromId { get; set; }
        public string username { get; set; }

    }
}
