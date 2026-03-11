using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class ScheduleRepaireRepository(AssetTrackingDbContext _dbContext) : IScheduleRepairRepository
    {
      
        public async Task<ScheduleRepairEntity?> AddAsync(
            ScheduleRepairEntity roleEntity,
            CancellationToken ct = default)
        {
            if (roleEntity == null)
            {
                throw new ArgumentNullException(nameof(roleEntity));
            }

            try
            {
                await _dbContext.ScheduleRepairs.AddAsync(roleEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return roleEntity;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(
            string id,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            var entity = await _dbContext.ScheduleRepairs
                .FirstOrDefaultAsync(e => e.ScheduleRepairId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.ScheduleRepairs.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ScheduleRepairEntity?>> GetAllAsync(CancellationToken ct = default)
        {
            return  await _dbContext.ScheduleRepairs
                          .AsNoTracking()
                          .Include(a => a.RepairStatus)
                          .Include(a => a.Asset)
                          .ToListAsync(ct);
        }

        public async Task<ScheduleRepairEntity?> GetByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return await _dbContext.ScheduleRepairs
                .FirstOrDefaultAsync(e => e.ScheduleRepairId == id);
        }

        public async Task<bool> UpdateAsync(
            string id,
            ScheduleRepairEntity roleEntity,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            if (roleEntity == null)
            {
                throw new ArgumentNullException(nameof(roleEntity));
            }

            if (roleEntity.ScheduleRepairId != id)
            {
                return false;
            }

            var existing = await _dbContext.ScheduleRepairs
                .FirstOrDefaultAsync(e => e.ScheduleRepairId == id, ct);

            if (existing == null)
            {
                return false;
            }

            

            try
            {
                _dbContext.ScheduleRepairs.Update(roleEntity);
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