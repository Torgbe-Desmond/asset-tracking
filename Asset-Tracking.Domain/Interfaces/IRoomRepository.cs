using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface IRoomRepository
    {
        Task<RoomEntity?> AddAsync(RoomEntity roomEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, RoomEntity roomEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<RoomEntity?> GetByIdAsync(int id);

        Task<IEnumerable<RoomEntity>> GetAllAsync(CancellationToken ct = default);
    }
}
