using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class ConnectionService : IConnectionService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConnectionRepository _connectionRepository;
        private readonly IMapper _mapper;

        public ConnectionService(IServiceProvider serviceProvider)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            _connectionRepository = serviceProvider.GetRequiredService<IConnectionRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }

        public async Task<Response<ReturnConnectionDTO>> AddConnection(ReceieveConnectionDTO conn)
        {
            Response<ReturnConnectionDTO> response = new Response<ReturnConnectionDTO>();
            var user = await _userManager.FindByNameAsync(conn.UserName_To);
            if(user is null)
            {
                response.Message = $"User with user name ${conn.UserName_To} does not exist";
                return response;
            }

            conn.UserId_To = user.Id;
            
            var connection = _mapper.Map<Connection>(conn);
            var result = await _connectionRepository.Add(connection);
            if (result)
            {
                response.Data = _mapper.Map<ReturnConnectionDTO>(connection);
                response.Message = "Connection Added";
                response.Success = true;

                return response;
            }

            response.Message = "Something went wrong";
            return response;
        }

        public async Task<bool> RemoveConnection(string Id)
        {
            var conn = await _connectionRepository.GetById(Id);
            if (conn is null)
                return false;
            return await _connectionRepository.DeleteById(conn);
        }
    }
}
