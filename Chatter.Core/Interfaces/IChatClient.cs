namespace Chatter.Core.Interfaces;

public interface IChatClient
{
    Task ReceiveMessage(MessageDto dto);
    Task UserJoined(string userName);
}
