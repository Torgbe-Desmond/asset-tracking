using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IUserImageRepository
    {
        Task<UserImageEntity?> AddAsync(UserImageEntity userImageEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int USerImageId, UserImageEntity userImageEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int USerImageId, CancellationToken ct = default);
        Task<UserImageEntity?> GetByIdAsync(int USerImageId);
        Task<IEnumerable<UserImageEntity>> GetAllAsync(CancellationToken ct = default);


    }
}
