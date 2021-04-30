using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsApplication.Core.Services;
using UsApplication.DTOs;
using UsApplication.Models;

namespace KingdomCommunication.API.Controllers
{
    
    [ApiController]
    [Route("[controller]/[action]")]
    public class ConnectionController: ControllerBase
    {
        private readonly IConnectionService _connectionService;
        private readonly UserManager<User> _userManager;

        public ConnectionController(IServiceProvider serviceProvider)
        {
            _connectionService = serviceProvider.GetRequiredService<IConnectionService>();
            _userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        }

        [HttpPost]
        [Route("{Id}")]
        public async Task<IActionResult> Add(ReceieveConnectionDTO conn, string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            conn.UserName_From = user.UserName;
            conn.UserId_From = user.Id;
            var result = await _connectionService.AddConnection(conn);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction("Get", new { result.Data.Id }, result.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = await _connectionService.RemoveConnection(Id);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
