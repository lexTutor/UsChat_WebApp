using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsApplication.DTOs;
using UsApplication.Models;

namespace UsApplication.Core.Services
{
    public interface IMessageService
    {
        Task<Response<ICollection<ReturnMessageDTO>>> GetMessagesBetweenConnections(string fromId, string toId);

        Task<bool> DeleteMessage(string Id);

        Task<Response<ReturnMessageDTO>> AddMessage(ReceiveMessageDTO message);

        Task<bool> EditMessage(ReceiveMessageDTO message, string Id);
    }
}
