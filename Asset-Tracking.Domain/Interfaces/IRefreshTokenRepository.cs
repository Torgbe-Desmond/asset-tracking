using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshTokenEntity?> AddAsync(RefreshTokenEntity refreshTokenEntity, CancellationToken ct = default);
        Task<RefreshTokenEntity?> UpdateAsync(int id, RefreshTokenEntity refreshTokenEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<RefreshTokenEntity?> GetByIdAsync(int id);
    }
}
