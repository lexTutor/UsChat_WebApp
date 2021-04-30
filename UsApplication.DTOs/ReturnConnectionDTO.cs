using System;
using System.Collections.Generic;
using System.Text;

namespace UsApplication.DTOs
{
    public class ReturnConnectionDTO
    {
        public string Id { get; set; }
        public string UserName_To { get; set; }

        public string UserId_To { get; set; }

        public string UserName_From { get; set; }

        public string UserId_From { get; set; }
    }
}
