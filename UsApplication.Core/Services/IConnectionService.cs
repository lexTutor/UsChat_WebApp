using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UsApplication.DTOs;
using UsApplication.Models;

namespace UsApplication.Core.Services
{
    public interface IConnectionService
    {
        Task<bool> RemoveConnection(string Id);
        Task<Response<ReturnConnectionDTO>> AddConnection(ReceieveConnectionDTO conn);

    }
}
