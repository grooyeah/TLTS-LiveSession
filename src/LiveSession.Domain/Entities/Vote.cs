using LiveSession.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSession.Domain.Entities;

public sealed class Vote : Entity
{
    public Guid PollOptionId { get; private set; }
    public string ParticipantId { get; private set; } = string.Empty;
    public DateTime CastAt { get; private set; }

    private Vote() { }

    public static Vote Create(Guid pollOptionId, string participantId) => new()
    {
        PollOptionId = pollOptionId,
        ParticipantId = participantId,
        CastAt = DateTime.UtcNow
    };
}
