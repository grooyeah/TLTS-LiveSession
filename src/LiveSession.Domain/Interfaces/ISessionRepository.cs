using LiveSession.Domain.Entities;
using LiveSession.Domain.ValueObjects;

namespace LiveSession.Domain.Interfaces;

public interface ISessionRepository
{
    Task<Session?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<Session?> GetByCodeAsync(SessionCode code, CancellationToken ct = default);
    Task AddAsync(Session session, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}