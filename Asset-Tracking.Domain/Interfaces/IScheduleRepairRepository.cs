using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IScheduleRepairRepository
    {
        Task<ScheduleRepairEntity?> AddAsync(ScheduleRepairEntity roleEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(string id, ScheduleRepairEntity roleEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(string id, CancellationToken ct = default);
        Task<ScheduleRepairEntity?> GetByIdAsync(string id);
        Task<IEnumerable<ScheduleRepairEntity?>> GetAllAsync(CancellationToken ct = default);
    }
}
