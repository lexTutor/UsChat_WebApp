﻿using System;
using System.ComponentModel.DataAnnotations;

namespace UsApplication.DTOs
{
    public class ReceiveUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email{ get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
