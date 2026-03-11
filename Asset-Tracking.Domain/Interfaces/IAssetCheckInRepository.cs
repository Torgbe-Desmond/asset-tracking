using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IAssetCheckInRepository
    {
        Task<AssetCheckInEntity?> AddAsync(AssetCheckInEntity assetCheckIn, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, AssetCheckInEntity assetCheckIn, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<AssetCheckInEntity?> GetByIdAsync(int id);
        Task<IEnumerable<AssetCheckInEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
