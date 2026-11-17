using Chatter.Core;
using Chatter.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Chatter.API.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(string message, string userName)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            message = message.Trim();

            if (message.Length > 1000)
                message = message.Remove(1000, message.Length - 1000);

            var dto = new MessageDto(
                string.IsNullOrWhiteSpace(userName) ? "anonymous" : userName, 
                message,
                DateTimeOffset.UtcNow);

            await Clients.All.ReceiveMessage(dto);
        }
    }
}
