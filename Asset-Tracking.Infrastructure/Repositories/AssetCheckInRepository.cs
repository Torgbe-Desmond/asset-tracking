using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class AssetCheckInRepository(AssetTrackingDbContext _dbContext) : IAssetCheckInRepository
    {
    
        public async Task<AssetCheckInEntity?> AddAsync(
            AssetCheckInEntity assetCheckIn, 
            CancellationToken ct = default)
        {
            if (assetCheckIn == null)
            {
                return null;
            }

            try
            {
                await _dbContext.AssetCheckIns.AddAsync(assetCheckIn, ct);
                await _dbContext.SaveChangesAsync(ct);
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return assetCheckIn;
        }

        public async Task<bool> DeleteAsync(
            int id, 
            CancellationToken ct = default)
        {
           
            var entity = await _dbContext.AssetCheckOuts
                .FirstOrDefaultAsync(e => e.AssetCheckOutId == id, ct);

            if (entity == null)
            {
                return false;
            }
            
            _dbContext.AssetCheckOuts.Remove(entity);

            try
            {
                await _dbContext.SaveChangesAsync(ct);
            }
            catch (DbUpdateException)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<AssetCheckInEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.AssetCheckIns
                         .AsNoTracking()
                         .Include(e=> e.Asset)
                         .Include(e=> e.Site)
                         .Include(e => e.Staff)
                         .ToListAsync(ct);
        }

        public async Task<AssetCheckInEntity?> GetByIdAsync(int id)
        {
      
            return await _dbContext.AssetCheckIns
                .FirstOrDefaultAsync(e => e.AssetCheckInId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            AssetCheckInEntity assetCheckIn, 
            CancellationToken ct = default)
        {
            if (assetCheckIn == null)
            {
                return false;
            }

            if (assetCheckIn.AssetCheckInId != id)
            {
                return false;
            }

            var existing = await _dbContext.AssetCheckIns
                .FirstOrDefaultAsync(e => e.AssetCheckInId == id, ct);

            if (existing == null)
            {
                return false;
            }
            _dbContext.AssetCheckIns.Update(assetCheckIn);

            try
            {
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