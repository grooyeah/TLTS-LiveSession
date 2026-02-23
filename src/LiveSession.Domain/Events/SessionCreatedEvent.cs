using LiveSession.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSession.Domain.Events;

public record SessionCreatedEvent(Guid SessionId, string Code) : IDomainEvent;