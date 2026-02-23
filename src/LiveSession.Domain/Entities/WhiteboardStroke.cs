using LiveSession.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSession.Domain.Entities;

public sealed class WhiteboardStroke : Entity
{
    public Guid SessionId { get; private set; }
    public string PointsJson { get; private set; } = string.Empty;
    public string Color { get; private set; } = string.Empty;
    public int Thickness { get; private set; }
    public DateTime DrawnAt { get; private set; }

    private WhiteboardStroke() { }

    public static WhiteboardStroke Create(Guid sessionId, string pointsJson, string color, int thickness) => new()
    {
        SessionId = sessionId,
        PointsJson = pointsJson,
        Color = color,
        Thickness = thickness,
        DrawnAt = DateTime.UtcNow
    };
}