using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsApplication.DTOs;
using UsApplication.Models;

namespace UsApplication.Core.Services
{
    public interface IUserService
    {
        Task<Response<ReturnUserDTO>> GetUser(string userId);
        Task<Response<string>> Login(LoginUserDTO user);
        Task<bool> DeleteUser(string Id);

        Task<Response<ReturnUserDTO>> AddUser(ReceiveUserDTO user);

        Task<bool> EditUser(ReceiveUserDTO user, string Id);
    }
}
