using LiveSession.Domain.Common;
using LiveSession.Domain.Enums;
using LiveSession.Domain.Events;
using LiveSession.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSession.Domain.Entities;

public sealed class Session : Entity
{
    public string Title { get; private set; } = string.Empty;
    public SessionCode Code { get; private set; } = null!;
    public string HostId { get; private set; } = string.Empty;
    public SessionStatus Status { get; private set; } = SessionStatus.Waiting;
    public DateTime CreatedAt { get; private set; }
    public DateTime? StartedAt { get; private set; }
    public DateTime? EndedAt { get; private set; }

    private readonly List<Poll> _polls = [];
    private readonly List<Question> _questions = [];

    public IReadOnlyList<Poll> Polls => _polls.AsReadOnly();
    public IReadOnlyList<Question> Questions => _questions.AsReadOnly();

    private Session() { } // EF Core needs this

    public static Session Create(string title, string hostId)
    {
        var session = new Session
        {
            Title = title,
            HostId = hostId,
            Code = SessionCode.New(),
            Status = SessionStatus.Waiting,
            CreatedAt = DateTime.UtcNow
        };

        session.RaiseDomainEvent(new SessionCreatedEvent(session.Id, session.Code.Value));
        return session;
    }

    public void Start()
    {
        if (Status != SessionStatus.Waiting)
            throw new InvalidOperationException("Only a waiting session can be started.");

        Status = SessionStatus.Active;
        StartedAt = DateTime.UtcNow;
        RaiseDomainEvent(new SessionStartedEvent(Id));
    }

    public void End()
    {
        if (Status != SessionStatus.Active)
            throw new InvalidOperationException("Only an active session can be ended.");

        Status = SessionStatus.Ended;
        EndedAt = DateTime.UtcNow;
        RaiseDomainEvent(new SessionEndedEvent(Id));
    }
}
