namespace Chatter.Core.Interfaces
{
    public interface IMessageStore
    {
        Task AddMessageAsync(MessageDto message);
        IReadOnlyList<MessageDto> GetRecent();
    }
}
