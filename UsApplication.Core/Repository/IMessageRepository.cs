using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsApplication.Models;

namespace UsApplication.Core.Repository
{
    public interface IMessageRepository: IGenericRepository<Message>
    {
        Task<ICollection<Message>> GetMessagesBetweenConnections(string fromId, string toId);
    }
}
