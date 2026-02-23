using LiveSession.Domain.Entities;

namespace LiveSession.Domain.Interfaces;

public interface IPollRepository
{
    Task<Poll?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task AddAsync(Poll poll, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}