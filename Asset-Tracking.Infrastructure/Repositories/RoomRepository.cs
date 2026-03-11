using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class RoomRepository(AssetTrackingDbContext _dbContext) : IRoomRepository
    {
       
        public async Task<RoomEntity?> AddAsync(
            RoomEntity roomEntity,
            CancellationToken ct = default)
        {
            if (roomEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.Rooms.AddAsync(roomEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return roomEntity;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(
            int id,
            CancellationToken ct = default)
        {
           
            var entity = await _dbContext.Rooms
                .FirstOrDefaultAsync(e => e.RoomId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.Rooms.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<RoomEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Rooms.ToListAsync(ct);
        }

        public async Task<RoomEntity?> GetByIdAsync(int id)
        {
        
            return await _dbContext.Rooms
                .FirstOrDefaultAsync(e => e.RoomId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            RoomEntity roomEntity,
            CancellationToken ct = default)
        {
      
            if (roomEntity.RoomId != id)
            {
                return false;
            }

            var existing = await _dbContext.Rooms
                .FirstOrDefaultAsync(e => e.RoomId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {   _dbContext.Rooms.Update(roomEntity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }
    }
}