using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IAssetRepository
    {
        Task<IEnumerable<AssetEntity?>> GetAllAsync(CancellationToken ct = default);
        Task<AssetEntity?> CreateAsync(AssetEntity assetEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, AssetEntity assetEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<AssetEntity?> GetByIdAsync(int id);
        Task<AssetEntity?> GetByNameAsync(string assetName);
        Task<AssetEntity?> GetByTagIdAsync(string tagId);


    }
}
