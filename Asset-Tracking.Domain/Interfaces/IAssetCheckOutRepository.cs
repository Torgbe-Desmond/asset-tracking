using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IAssetCheckOutRepository
    {
        Task<AssetCheckOutEntity?> AddAsync(AssetCheckOutEntity roleEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, AssetCheckOutEntity roleEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<AssetCheckOutEntity?> GetByIdAsync(int id);
        Task<IEnumerable<AssetCheckOutEntity>?> GetAllAsync(CancellationToken ct = default); 

    }
}
