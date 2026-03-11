using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IAssetCategoryRepository
    {
        Task<AssetCategoryEntity?> AddAsync(AssetCategoryEntity roleEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, AssetCategoryEntity roleEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<AssetCategoryEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<AssetCategoryEntity>?> GetAllAsync(CancellationToken ct = default);

        
    }
}
    