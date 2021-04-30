using System;
using System.Collections.Generic;
using System.Text;

namespace UsApplication.Core.Concrete
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
