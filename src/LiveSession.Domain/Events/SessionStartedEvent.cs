using LiveSession.Domain.Common;

namespace LiveSession.Domain.Events;

public record SessionStartedEvent(Guid SessionId) : IDomainEvent;
