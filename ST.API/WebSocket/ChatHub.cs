using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ST.API.WebSocket
{
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("OnMessage", $"{Context.ConnectionId} has joined the hub.");
            await base.OnConnectedAsync();
        }

        public async Task ChatMessage(Response response)
        {
            await Clients.All.SendAsync("OnMessage", $"{Context.ConnectionId} said: \"{response.Username}\" \t \"{response.Message}\"");
        }
    }

    public class Response
    {
        public string Username { get; set; }
        public string Message { get; set; }
    }
}