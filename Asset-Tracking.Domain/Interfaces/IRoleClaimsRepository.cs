using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IRoleClaimsRepository
    {
        Task<RoleClaimsEntity?> AddAsync(RoleClaimsEntity roleclaimEntity, CancellationToken ct = default);
        Task<RoleClaimsEntity?> UpdateAsync(int id, RoleClaimsEntity roleclaimEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<RoleClaimsEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<RoleClaimsEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
