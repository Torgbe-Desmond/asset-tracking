using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class AssetMaintenanceRepository(AssetTrackingDbContext _dbContext) : IAssetMaintenanceRepository
    {
        public async Task<AssetMaintenanceEntity?> AddAsync(
            AssetMaintenanceEntity roleEntity,
            CancellationToken ct = default)
        {
            if (roleEntity == null)
            {
                throw new ArgumentNullException(nameof(roleEntity));
            }

            try
            {
                await _dbContext.AssetMaintenances.AddAsync(roleEntity, ct);
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

            var entity = await _dbContext.AssetMaintenances
                .FirstOrDefaultAsync(e => e.AssetMaintenanceId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.AssetMaintenances.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AssetMaintenanceEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.AssetMaintenances
                 .AsNoTracking()
                 .Include(e => e.Asset)
                 .Include(e => e.MaintenanceStatus)
                 .ToListAsync(ct);
                
        }

        public async Task<AssetMaintenanceEntity?> GetByIdAsync(int id)
        {
          

            return await _dbContext.AssetMaintenances
                .FirstOrDefaultAsync(e => e.AssetMaintenanceId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            AssetMaintenanceEntity roleEntity,
            CancellationToken ct = default)
        {
       
            if (roleEntity == null)
            {
                return false;
            }

            if (roleEntity.AssetMaintenanceId != id)
            {
                return false;
            }

            var existing = await _dbContext.AssetMaintenances
                .FirstOrDefaultAsync(e => e.AssetMaintenanceId == id, ct);

            if (existing == null)
            {
                return false;
            }

         
            try
            {
                _dbContext.AssetMaintenances.Update(roleEntity);
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