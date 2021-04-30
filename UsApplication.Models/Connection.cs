using System;
using System.Collections.Generic;
using System.Text;

namespace UsApplication.Models
{
    public class Connection
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserName_To { get; set; }

        public string UserId_To { get; set; }

        public string UserName_From { get; set; }

        public string UserId_From { get; set; }

        public virtual User User { get; set; }
    }
}
