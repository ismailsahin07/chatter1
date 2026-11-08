namespace Chatter.Core;

public class Message
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Payload { get; set; }
    public DateTimeOffset SentAt { get; set; } = DateTimeOffset.UtcNow;
}
