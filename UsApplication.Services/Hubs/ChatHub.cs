using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UsApplication.Implementation.Hubs
{
    [Authorize]
    public class ChatHub: Hub
    {
        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;
            Groups.AddToGroupAsync(Context.ConnectionId, name);
            return base.OnConnectedAsync();
        }
        public async Task SendMessageAsync(string userName, string message)
        {
             await  Clients.Group(userName).SendAsync("ReceieveMessage", message);
             await Clients.OthersInGroup(Context.User.Identity.Name).SendAsync("ReceieveMessage", message);
        }

    }
}