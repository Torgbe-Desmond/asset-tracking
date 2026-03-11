using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IRepairStatusRepository
    {
        Task<RepairStatusEntity?> AddAsync(RepairStatusEntity repairStatusEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, RepairStatusEntity repairStatusEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<RepairStatusEntity?> GetByIdAsync(int id);
        Task<IEnumerable<RepairStatusEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
