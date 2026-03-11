using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IAssetStatusRepository
    {
        Task<AssetStatusEntity?> AddAsync(AssetStatusEntity assetStatusEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, AssetStatusEntity assetStatusEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<AssetStatusEntity?> GetByIdAsync(int id);
    }
}
