namespace Chatter.Core;

public record MessageDto(string User, string Payload, DateTimeOffset SentAt);
