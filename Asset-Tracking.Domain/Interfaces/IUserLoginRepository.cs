using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IUserLoginRepository
    {
        Task<UserLoginEntity?> AddAsync(UserLoginEntity userLoginEntity, CancellationToken ct = default);
        Task<UserLoginEntity?> UpdateAsync(string id, UserLoginEntity userLoginEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(string id, CancellationToken ct = default);
        Task<UserLoginEntity?> GetByIdAsync(string id);
    }
}
