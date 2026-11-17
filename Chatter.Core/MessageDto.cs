namespace Chatter.Core;

public record MessageDto(string User, Guid Id, string Payload, DateTimeOffset SentAt);
