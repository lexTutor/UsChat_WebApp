using System;
using System.Collections.Generic;
using System.Text;

namespace UsApplication.Models
{
    public class Response<TData>
    {
        public bool Success { get; set; }

        public TData Data { get; set; }

        public string Message { get; set; }
    }
}
