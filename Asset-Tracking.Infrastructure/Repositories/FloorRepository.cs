using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class FloorRepository(AssetTrackingDbContext _dbContext) : IFloorRepository
    {
        public async Task<FloorEntity?> AddAsync(
            FloorEntity floorEntity,
            CancellationToken ct = default)
        {
            if (floorEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.Floors.AddAsync(floorEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return floorEntity;
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
  
            var entity = await _dbContext.Floors
                .FirstOrDefaultAsync(e => e.FloorId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.Floors.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<FloorEntity>?> GetAllAsync(CancellationToken ct = default)
        {
           return await _dbContext.Floors.ToListAsync();
        }

        public async Task<FloorEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.Floors
                .FirstOrDefaultAsync(e => e.FloorId == id,ct);
        }

        public async Task<bool> UpdateAsync(
            int id,
            FloorEntity floorEntity,
            CancellationToken ct = default)
        {
     
            var existing = await _dbContext.Floors
                .FirstOrDefaultAsync(e => e.FloorId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.Floors.Update(floorEntity);
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