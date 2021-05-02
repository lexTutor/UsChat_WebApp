using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsApplication.Core.Services;
using UsApplication.DTOs;
using UsApplication.Implementation.Hubs;
using UsApplication.Models;

namespace KingdomCommunication.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<User> _userManager;
        private readonly IHubContext<ChatHub> _hubContext;

        public MessageController(IServiceProvider serviceProvider)
        {
            _messageService = serviceProvider.GetRequiredService<IMessageService>();
            _userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            _hubContext = serviceProvider.GetRequiredService<IHubContext<ChatHub>>();

        }

        [HttpGet]
        [Route("{IdTo}/{IdFrom}")]
        public async Task<IActionResult> Get(string IdTo, string IdFrom)
        {
            var result = await _messageService.GetMessagesBetweenConnections(IdTo, IdFrom);
            return !result.Success ? BadRequest(result) : StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPost]
        [Route("{Id}")]
        public async Task<IActionResult> Add(ReceiveMessageDTO message)
        {
           var userTo = await _userManager.FindByIdAsync(message.userToId);

           var result = await _messageService.AddMessage(message);

           await _hubContext.Clients.GroupExcept(HttpContext.User.Identity.Name, HttpContext.Connection.Id).SendAsync("ReceieveMessage", message);
            
           await _hubContext.Clients.Group(userTo.Id).SendAsync("ReceieveMessage", message);
            
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction("Get", new { result.Data.Id }, result.Data);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit(ReceiveMessageDTO message, string Id)
        {
            var result = await _messageService.EditMessage(message, Id);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = await _messageService.DeleteMessage(Id);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
