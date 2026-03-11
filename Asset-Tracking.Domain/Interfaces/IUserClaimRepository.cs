using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IUserClaimRepository
    {
        Task<UserClaimsEntity?> AddAsync(UserClaimsEntity userClaimEntity, CancellationToken ct = default);
        Task<UserClaimsEntity?> UpdateAsync(int id, UserClaimsEntity userClaimEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<UserClaimsEntity?> GetByIdAsync(int id);
    }
}
