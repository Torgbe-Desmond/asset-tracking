using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity?> AddAsync(UserEntity userEntity, CancellationToken ct = default);
        Task<UserEntity?> UpdateAsync(string id, UserEntity userEntity, CancellationToken ct = default);
        Task<bool?> DeleteAsync(string id, CancellationToken ct = default);
        Task<UserEntity?> GetByIdAsync(string id);
        Task<UserEntity?> GetByEmailAsync(string email);

        Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken ct = default);
    }
}
