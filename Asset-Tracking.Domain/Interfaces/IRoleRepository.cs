using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IRoleRepository
    {
        Task<RoleEntity?> AddAsync(RoleEntity roleEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(string id, RoleEntity roleEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(string id, CancellationToken ct = default);
        Task<RoleEntity?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<IEnumerable<RoleEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
