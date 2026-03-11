using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IAssetRepairRepository
    {
        Task<AssetRepairEntity?> AddAsync(AssetRepairEntity assetRepairEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, AssetRepairEntity assetRepairEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<AssetRepairEntity?> GetByIdAsync(int id);
        Task<IEnumerable<AssetRepairEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
