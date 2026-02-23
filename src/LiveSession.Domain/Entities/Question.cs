using LiveSession.Domain.Common;
using LiveSession.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSession.Domain.Entities;

public sealed class Question : Entity
{
    public Guid SessionId { get; private set; }
    public string Text { get; private set; } = string.Empty;
    public string AskedBy { get; private set; } = string.Empty;
    public QuestionStatus Status { get; private set; } = QuestionStatus.Open;
    public int UpvoteCount { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Question() { }

    public static Question Create(Guid sessionId, string text, string askedBy) => new()
    {
        SessionId = sessionId,
        Text = text,
        AskedBy = askedBy,
        Status = QuestionStatus.Open,
        UpvoteCount = 0,
        CreatedAt = DateTime.UtcNow
    };

    public void Upvote() => UpvoteCount++;

    public void MarkAnswered()
    {
        if (Status != QuestionStatus.Open)
            throw new InvalidOperationException("Only open questions can be marked as answered.");
        Status = QuestionStatus.Answered;
    }

    public void Dismiss()
    {
        if (Status != QuestionStatus.Open)
            throw new InvalidOperationException("Only open questions can be dismissed.");
        Status = QuestionStatus.Dismissed;
    }
}
