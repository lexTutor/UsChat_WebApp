using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsApplication.DTOs
{
    public class LoginUserDTO
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
