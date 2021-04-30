using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsApplication.Core.Repository;
using UsApplication.Core.Services;
using UsApplication.DTOs;
using UsApplication.Models;

namespace UsApplication.Implementation.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepositoryy;
        private readonly IMapper _mapper;

        public MessageService(IServiceProvider serviceProvider)
        {
            _messageRepositoryy = serviceProvider.GetRequiredService<IMessageRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
        public async Task<Response<ReturnMessageDTO>> AddMessage(ReceiveMessageDTO message)
        {
            Response<ReturnMessageDTO> response = new Response<ReturnMessageDTO>();
            var theMessage = _mapper.Map<Message>(message);
            var result = await _messageRepositoryy.Add(theMessage);

            if (result)
            {
                response.Data = _mapper.Map<ReturnMessageDTO>(theMessage);
                response.Success = true;
                response.Message = "Sent";

                return response;
            }

            response.Message = "Not Sent";
            return response;
        }

        public async Task<bool> DeleteMessage(string Id)
        {
            var msg = await _messageRepositoryy.GetById(Id);
            if (msg is null)
                return false;
            return _messageRepositoryy.DeleteById(msg).Result;
        }

        public async Task<bool> EditMessage(ReceiveMessageDTO message, string Id)
        {
            var msg = await _messageRepositoryy.GetById(Id);
            if (msg is null)
                return false;
            msg.MessageDetails = message.MessageDetails != string.Empty ? message.MessageDetails : msg.MessageDetails;
            return _messageRepositoryy.Modify(msg).Result;
        }

        public async Task<Response<ICollection<ReturnMessageDTO>>> GetMessagesBetweenConnections(string fromId, string toId)
        {
            Response<ICollection<ReturnMessageDTO>> response = new Response<ICollection<ReturnMessageDTO>>();
            var msgs = await _messageRepositoryy.GetMessagesBetweenConnections(fromId, toId);
            if(msgs != null)
            {
                response.Data = _mapper.Map<ICollection<ReturnMessageDTO>>(msgs);
                response.Success = true;
                response.Message = "All messages";
                return response;
            }

            response.Message = "No message found";
            return response;
        }
    }
}
