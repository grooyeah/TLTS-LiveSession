using LiveSession.Domain.Entities;

namespace LiveSession.Domain.Interfaces;

public interface IQuestionRepository
{
    Task<Question?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<List<Question>> GetBySessionIdAsync(Guid sessionId, CancellationToken ct = default);
    Task AddAsync(Question question, CancellationToken ct = default);
    Task SaveChangesAsync(CancellationToken ct = default);
}
