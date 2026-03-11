using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IAssetImageRepository
    {
        Task<AssetImageEntity?> AddAsync(AssetImageEntity assetImageEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, AssetImageEntity assetImageEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<AssetImageEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<AssetImageEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
