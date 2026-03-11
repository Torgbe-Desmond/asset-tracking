using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IUserTokenRepository
    {
        Task<UserTokenEntity?> AddAsync(UserTokenEntity userTokenEntity, CancellationToken ct = default);
        Task<UserTokenEntity?> UpdateAsync(string id, UserTokenEntity userTokenEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(string id, CancellationToken ct = default);
        Task<UserTokenEntity?> GetAsync(string UserId, string LoginProvider, string Name);
    }
}
