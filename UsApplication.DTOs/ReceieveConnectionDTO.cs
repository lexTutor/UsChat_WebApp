using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UsApplication.DTOs
{
    public class ReceieveConnectionDTO
    {
        [Required]
        public string UserName_To { get; set; }

        public string UserId_To { get; set; }

        public string UserName_From { get; set; }

        public string UserId_From { get; set; }
    }
}
