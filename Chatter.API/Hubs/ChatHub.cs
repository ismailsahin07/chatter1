using Chatter.Core;
using Chatter.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Chatter.API.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(string message, string userName)
        {
            var dto = new MessageDto(
                userName,
                message,
                DateTimeOffset.UtcNow);

            await Clients.All.ReceiveMessage(dto);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Others.UserJoined(Context.UserIdentifier ?? "Anonymous");
            await base.OnConnectedAsync();
        }
    }
}
