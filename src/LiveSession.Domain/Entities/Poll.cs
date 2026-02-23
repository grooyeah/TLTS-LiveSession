using LiveSession.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSession.Domain.Entities;

public sealed class Poll : Entity
{
    public Guid SessionId { get; private set; }
    public string Question { get; private set; } = string.Empty;
    public bool IsOpen { get; private set; } = true;
    public DateTime CreatedAt { get; private set; }

    private readonly List<PollOption> _options = [];
    public IReadOnlyList<PollOption> Options => _options.AsReadOnly();

    private Poll() { }

    public static Poll Create(Guid sessionId, string question, IEnumerable<string> options)
    {
        var poll = new Poll
        {
            SessionId = sessionId,
            Question = question,
            IsOpen = true,
            CreatedAt = DateTime.UtcNow
        };

        foreach (var option in options)
            poll._options.Add(PollOption.Create(poll.Id, option));

        return poll;
    }

    public void Close() => IsOpen = false;
}
