using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class BuildingRepository(AssetTrackingDbContext _dbContext) : IBuildingRepository
    {
       
        public async Task<BuildingEntity?> AddAsync(
            BuildingEntity roleEntity,
            CancellationToken ct = default)
        {
            if (roleEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.Buildings.AddAsync(roleEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return roleEntity;
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
  
            var entity = await _dbContext.Buildings
                .FirstOrDefaultAsync(e => e.BuildingId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.Buildings.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<BuildingEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Buildings.ToListAsync(ct);
        }
            
        public async Task<BuildingEntity?> GetByIdAsync(int id)
        {
    
            return await _dbContext.Buildings
                .FirstOrDefaultAsync(e => e.BuildingId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            BuildingEntity roleEntity,
            CancellationToken ct = default)
        {
      
            if (roleEntity == null)
            {
                return false;
            }

            if (roleEntity.BuildingId != id)
            {
                return false;
            }

            var existing = await _dbContext.Buildings
                .FirstOrDefaultAsync(e => e.BuildingId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.Buildings.Update(roleEntity);
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