using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsApplication.Models;

namespace UsApplication.Core.Repository
{
    public interface IConnectionRepository: IGenericRepository<Connection>
    {
        Task<ICollection<Connection>> GetConnections(string Id);
    }
}
