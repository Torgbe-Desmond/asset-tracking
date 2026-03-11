using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class AssetRepairRepository(AssetTrackingDbContext _dbContext) : IAssetRepairRepository
    {
       
        public async Task<AssetRepairEntity?> AddAsync(
            AssetRepairEntity roleEntity,
            CancellationToken ct = default)
        {
            if (roleEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.AssetRepairs.AddAsync(roleEntity, ct);
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
        

            var entity = await _dbContext.AssetRepairs
                .FirstOrDefaultAsync(e => e.AssetRepairId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.AssetRepairs.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AssetRepairEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.AssetRepairs.AsNoTracking().Include(e=>e.Asset).ToListAsync();
        }

        public async Task<AssetRepairEntity?> GetByIdAsync(int id)
        {
          
            return await _dbContext.AssetRepairs
                .FirstOrDefaultAsync(e => e.AssetRepairId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            AssetRepairEntity roleEntity,
            CancellationToken ct = default)
        {
        
            if (roleEntity == null)
            {
                return false;
            }

            if (roleEntity.AssetRepairId != id)
            {
                return false;
            }

            var existing = await _dbContext.AssetRepairs
                .FirstOrDefaultAsync(e => e.AssetRepairId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.AssetRepairs.Update(roleEntity);
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