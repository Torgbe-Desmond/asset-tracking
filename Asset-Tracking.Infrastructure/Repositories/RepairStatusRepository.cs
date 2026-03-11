using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class RepairStatusRepository(AssetTrackingDbContext _dbContext) : IRepairStatusRepository
    {

        public async Task<RepairStatusEntity?> AddAsync(
            RepairStatusEntity repairStatusEntity,
            CancellationToken ct = default)
        {
            if (repairStatusEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.RepairStatuses.AddAsync(repairStatusEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return repairStatusEntity;
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
          
            var entity = await _dbContext.RepairStatuses
                .FirstOrDefaultAsync(e => e.RepairStatusId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.RepairStatuses.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<RepairStatusEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.RepairStatuses.ToListAsync(ct);
        }

        public async Task<RepairStatusEntity?> GetByIdAsync(int id)
        {
  
            return await _dbContext.RepairStatuses
                .FirstOrDefaultAsync(e => e.RepairStatusId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            RepairStatusEntity repairStatusEntity,
            CancellationToken ct = default)
        {
         
            if (repairStatusEntity == null)
            {
                return false;
            }

            if (repairStatusEntity.RepairStatusId != id)
            {
                return false;
            }

            var existing = await _dbContext.RepairStatuses
                .FirstOrDefaultAsync(e => e.RepairStatusId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.RepairStatuses.Update(existing);
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