using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IFloorRepository
    {
        Task<FloorEntity?> AddAsync(FloorEntity floorEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, FloorEntity floorEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<FloorEntity?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<IEnumerable<FloorEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
