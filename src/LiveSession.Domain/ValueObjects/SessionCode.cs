using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSession.Domain.ValueObjects;

public sealed class SessionCode
{
    public string Value { get; }

    private SessionCode(string value) => Value = value;

    public static SessionCode New()
    {
        var code = Guid.NewGuid().ToString("N")[..8].ToUpper();
        return new SessionCode(code);
    }

    public static SessionCode From(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 8)
            throw new ArgumentException("Session code must be 8 characters.", nameof(value));

        return new SessionCode(value.ToUpper());
    }

    public override string ToString() => Value;
    public override bool Equals(object? obj) => obj is SessionCode other && Value == other.Value;
    public override int GetHashCode() => Value.GetHashCode();
}
