using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IMaintenanceStatusRepository
    {
        Task<MaintenanceStatusEntity?> AddAsync(MaintenanceStatusEntity maintenanceEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, MaintenanceStatusEntity maintenanceEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<MaintenanceStatusEntity?> GetByIdAsync(int id);
        Task<IEnumerable<MaintenanceStatusEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
