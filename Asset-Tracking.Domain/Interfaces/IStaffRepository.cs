using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IStaffRepository
    {
        Task<StaffEntity?> AddAsync(StaffEntity staffEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(string id, StaffEntity staffEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(string id, CancellationToken ct = default);
        Task<StaffEntity?> GetByIdAsync(string id, CancellationToken ct = default);
        Task<IEnumerable<StaffEntity>> GetAllAsync(CancellationToken ct = default);
    }
}

