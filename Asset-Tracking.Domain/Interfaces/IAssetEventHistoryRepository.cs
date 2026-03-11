using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IAssetEventHistoryRepository
    {
        Task<AssetEventHistoryEntity?> AddAsync(AssetEventHistoryEntity assetEventHistoryEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(string id, AssetEventHistoryEntity assetEventHistoryEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(string id, CancellationToken ct = default);
        Task<AssetEventHistoryEntity?> GetByIdAsync(string id);
        Task<IEnumerable<AssetEventHistoryEntity>> GetAllAsync(CancellationToken ct = default);

    }
}
