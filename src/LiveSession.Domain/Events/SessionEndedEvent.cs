using LiveSession.Domain.Common;

namespace LiveSession.Domain.Events;

public record SessionEndedEvent(Guid SessionId) : IDomainEvent;