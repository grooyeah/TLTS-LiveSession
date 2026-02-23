using LiveSession.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSession.Domain.Entities;

public sealed class PollOption : Entity
{
    public Guid PollId { get; private set; }
    public string Text { get; private set; } = string.Empty;

    private readonly List<Vote> _votes = [];
    public IReadOnlyList<Vote> Votes => _votes.AsReadOnly();

    private PollOption() { }

    public static PollOption Create(Guid pollId, string text) => new()
    {
        PollId = pollId,
        Text = text
    };

    public void AddVote(string participantId)
    {
        if (_votes.Any(v => v.ParticipantId == participantId))
            throw new InvalidOperationException("Participant has already voted on this poll.");

        _votes.Add(Vote.Create(Id, participantId));
    }
}