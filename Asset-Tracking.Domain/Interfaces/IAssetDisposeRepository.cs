using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IAssetDisposeRepository
    {
        Task<AssetDisposeEntity?> AddAsync(AssetDisposeEntity assetDispose, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, AssetDisposeEntity assetDispose, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<AssetDisposeEntity?> GetByIdAsync(int id);
        Task<IEnumerable<AssetDisposeEntity>?> GetAllAsync(CancellationToken ct = default);
    }
}
