using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IAssetMaintenanceRepository
    {
        Task<AssetMaintenanceEntity?> AddAsync(AssetMaintenanceEntity assetMaintenanceEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, AssetMaintenanceEntity assetMaintenanceEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<AssetMaintenanceEntity?> GetByIdAsync(int id);
        Task<IEnumerable<AssetMaintenanceEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
