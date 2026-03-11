using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    public class MaintenanceStatusRepository(
        AssetTrackingDbContext dbContext
    ) : IMaintenanceStatusRepository
    {
        public async Task<MaintenanceStatusEntity?> AddAsync(
            MaintenanceStatusEntity roleEntity,
            CancellationToken ct = default)
        {
            await dbContext.MaintenanceStatuses.AddAsync(roleEntity, ct);
            await dbContext.SaveChangesAsync(ct);
            return roleEntity;
        }

        public async Task<bool> DeleteAsync(
            int id,
            CancellationToken ct = default)
        {
            var entity = await dbContext.MaintenanceStatuses
                .FirstOrDefaultAsync(x => x.MaintenanceStatusId == id, ct);

            if (entity is null)
                return false;

            dbContext.MaintenanceStatuses.Remove(entity);
            await dbContext.SaveChangesAsync(ct);
            return true;
        }

        public async Task<IEnumerable<MaintenanceStatusEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await dbContext.MaintenanceStatuses.ToListAsync(ct);
        }

        public async Task<MaintenanceStatusEntity?> GetByIdAsync(int id)
        {
            return await dbContext.MaintenanceStatuses
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MaintenanceStatusId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            MaintenanceStatusEntity maintenanceEntity,
            CancellationToken ct = default)
        {
            var entity = await dbContext.MaintenanceStatuses
                .FirstOrDefaultAsync(x => x.MaintenanceStatusId == id, ct);

            if (entity is null)
                return false;

            try
            {
                entity.StatusName = maintenanceEntity.StatusName;
                entity.UpdatedBy = maintenanceEntity.UpdatedBy;
                entity.DateUpdated = maintenanceEntity.DateUpdated;

                await dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
    }
}
