using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface ITitleRepository
    {
        Task<TitleEntity?> AddAsync(TitleEntity titleEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, TitleEntity titleEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<TitleEntity?> GetByIdAsync(int id);
    }
}
