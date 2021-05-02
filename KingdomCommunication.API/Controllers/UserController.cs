using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using UsApplication.Core.Services;
using UsApplication.DTOs;

namespace KingdomCommunication.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IServiceProvider serviceProvider)
        {
            _userService = serviceProvider.GetRequiredService<IUserService>();
        }

        [HttpGet]
        [Route("{email}/{password}")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string password)
        {
           var result = await _userService.Login(new LoginUserDTO { EmailAddress = email, Password = password});
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> Get(string Id)
        {
            var result = await _userService.GetUser(Id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        [Route("{Id}")]
        public async Task<IActionResult> Image(IFormFile image, string Id)
        {
            var files = Request;
            var result = await _userService.UploadImage(image, Id);
            if (!result)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ReceiveUserDTO user)
        {
            var result = await _userService.AddUser(user);
            if (!result.Success)
                return BadRequest(result);
            return CreatedAtAction("Get", new { result.Data.Id }, result.Data);
        }

        [HttpPatch]
        public async Task<IActionResult> Edit(ReceiveUserDTO user, string Id)
        {
            var result = await _userService.EditUser(user, Id);
            if (!result)
                return BadRequest();
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = await _userService.DeleteUser(Id);
            if (!result)
                return BadRequest();
            return NoContent();
        }
    }
}
