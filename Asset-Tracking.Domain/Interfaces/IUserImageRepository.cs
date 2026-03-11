using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IUserImageRepository
    {
        Task<UserImageEntity?> AddAsync(UserImageEntity userImageEntity, CancellationToken ct = default);
        Task<UserImageEntity?> UpdateAsync(int id, UserImageEntity userImageEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<UserImageEntity?> GetByIdAsync(int id);

        Task<IEnumerable<UserImageEntity>> GetAllAsync(CancellationToken ct = default);


    }
}
