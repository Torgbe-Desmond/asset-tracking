using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IBuildingRepository
    {
        Task<BuildingEntity?> AddAsync(BuildingEntity buildingEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, BuildingEntity buildingEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<BuildingEntity?> GetByIdAsync(int id);
        Task<IEnumerable<BuildingEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
