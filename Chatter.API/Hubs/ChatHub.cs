using Chatter.Core;
using Chatter.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Chatter.API.Hubs
{
    public class ChatHub(IMessageStore store) : Hub<IChatClient>
    {
        public async Task SendMessage(string message, string userName)
        {
            if (string.IsNullOrWhiteSpace(message)) return;

            message = message.Trim();

            if (message.Length > 1000)
                message = message.Remove(1000, message.Length - 1000);

            var dto = new MessageDto(
                string.IsNullOrWhiteSpace(userName) ? "anonymous" : userName, 
                Guid.NewGuid(),
                message,
                DateTimeOffset.UtcNow);

            await store.AddMessageAsync(dto);

            await Clients.All.ReceiveMessage(dto);
        }

        public IReadOnlyList<MessageDto> GetRecentMessages()
        {
            return store.GetRecent();
        }  
    }
}
