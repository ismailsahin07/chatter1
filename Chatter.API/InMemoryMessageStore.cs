using Chatter.Core;
using Chatter.Core.Interfaces;

namespace Chatter.API
{
    public sealed class InMemoryMessageStore : IMessageStore
    {
        private readonly Lock _lock = new();
        private readonly List<MessageDto> _messages = new();
        private const int maxMessages = 50;

        public Task AddMessageAsync(MessageDto message)
        {
            lock (_lock)
            {
                _messages.Add(message);
                if (_messages.Count > maxMessages)
                    _messages.RemoveAt(0);
            }

            return Task.CompletedTask;
        }

        public IReadOnlyList<MessageDto> GetRecent()
        {
            lock(_lock)
            {
                int start = Math.Max(0, _messages.Count - maxMessages);
                return _messages.GetRange(start, _messages.Count - start);
            }
        }
    }
}
