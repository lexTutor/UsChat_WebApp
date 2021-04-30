using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UsApplication.Core.Repository;
using UsApplication.Core.Services;
using UsApplication.DTOs;
using UsApplication.Models;

namespace UsApplication.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConnectionRepository _connectionRepository;
        private readonly IMapper _mapper;

        public UserService(IServiceProvider serviceProvider)
        {
            _userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            _connectionRepository = serviceProvider.GetRequiredService<IConnectionRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
        }
        public async Task<Response<ReturnUserDTO>> AddUser(ReceiveUserDTO user)
        {
             var response = new Response<ReturnUserDTO>();
            var userToAdd = _mapper.Map<User>(user);
            var result = await _userManager.CreateAsync(userToAdd, user.Password);

            if (result.Succeeded)
            {
                response.Data = _mapper.Map<ReturnUserDTO>(userToAdd);
                response.Success = true;
                response.Message = "Not added";
                return response;
            }

            response.Message = "Not Added";
            return response;
        }

        public async Task<bool> DeleteUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user is null)
                return false;
            return  _userManager.DeleteAsync(user).Result.Succeeded;
        }

        public async Task<bool> EditUser(ReceiveUserDTO user, string Id)
        {
            var theUser = await _userManager.FindByIdAsync(Id);
            if (theUser is null)
            {
                return false;
            }
            theUser.UserName = user.UserName != string.Empty? user.UserName: theUser.UserName;

            return _userManager.UpdateAsync(theUser).Result.Succeeded;

        }

        public async Task<Response<string>> Login(LoginUserDTO user)
        {
            Response<string> response = new Response<string>();
            var theUser = await _userManager.FindByEmailAsync(user.EmailAddress);
            if (theUser is null)
            {
                response.Message = "Invalid credentials";
                response.Success = false;
                return response;
            }

            var check = await _userManager.CheckPasswordAsync(theUser, user.Password);
            if (!check)
            {
                response.Message = "Invalid credentials";
                response.Success = false;
                return response;
            }

            response.Message = "Successful";
            response.Data = theUser.Id;
            response.Success = true;
            return response;
        }

        public async Task<Response<ReturnUserDTO>> GetUser(string userId)
        {
            Response<ReturnUserDTO> response = new Response<ReturnUserDTO>();
            var theUser = await _userManager.FindByIdAsync(userId);
            if(theUser is null)
            {
                response.Message = "Error";
                return response;
            }

            
            response.Data = _mapper.Map<ReturnUserDTO>(theUser);
            var connections = await GetConnections(theUser.Id);
            response.Data.Connections = connections;
            response.Message = "Successful";
            response.Success = true;

            return response;
        }

        private async Task<ICollection<ReturnConnectionDTO>> GetConnections(string id)
        {
            var conns = await _connectionRepository.GetConnections(id);
            if (conns is null)
                return null;
            return _mapper.Map<ICollection<ReturnConnectionDTO>>(conns);
        }
    }
}
