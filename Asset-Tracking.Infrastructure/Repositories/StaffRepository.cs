using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    public class StaffRepository(AssetTrackingDbContext _dbContext) : IStaffRepository
    {
        public async Task<StaffEntity?> AddAsync(
            StaffEntity staffEntity,
            CancellationToken ct = default)
        {
            if (staffEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.Staff.AddAsync(staffEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return staffEntity;
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

            var entity = await _dbContext.Staff
                .FirstOrDefaultAsync(e => e.StaffId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.Staff.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<StaffEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Staff.AsNoTracking().ToListAsync();
        }

        public async Task<StaffEntity?> GetByIdAsync(string id, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return await _dbContext.Staff
                .FirstOrDefaultAsync(e => e.StaffId == id,ct);
        }

        public async Task<bool> UpdateAsync(
            string id,
            StaffEntity staffEntity,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            if (staffEntity == null)
            {
                return false;
            }

            if (staffEntity.StaffId != id)
            {
                return false;
            }

            var existing = await _dbContext.Staff
                .FirstOrDefaultAsync(e => e.StaffId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.Staff.Update(staffEntity);
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