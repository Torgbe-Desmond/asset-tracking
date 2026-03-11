using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IUserRolesRepository
    {
        Task<UserRolesEntity?> AddAsync(UserRolesEntity userRoleEntity, CancellationToken ct = default);
        Task<UserRolesEntity?> UpdateAsync(string id, UserRolesEntity userRoleEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(string id, CancellationToken ct = default);
        Task<UserRolesEntity?> GetAsync(string roleId, string userId);
    }
}
