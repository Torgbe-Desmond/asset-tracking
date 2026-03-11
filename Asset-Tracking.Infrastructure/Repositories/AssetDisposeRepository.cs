using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class AssetDisposeRepository(AssetTrackingDbContext _dbContext) : IAssetDisposeRepository
    {
       
        public async Task<AssetDisposeEntity?> AddAsync(
            AssetDisposeEntity assetDispose,
            CancellationToken ct = default)
        {
            if (assetDispose == null)
            {
                return null;
            }

            try
            {
                await _dbContext.AssetDisposals.AddAsync(assetDispose, ct);
                await _dbContext.SaveChangesAsync(ct);
            }
            catch (DbUpdateException)
            {
                return null;
            }


            return assetDispose;
        }

        public async Task<bool> DeleteAsync(
            int id,
            CancellationToken ct = default)
        {
           
            var entity = await _dbContext.AssetDisposals
                .FirstOrDefaultAsync(e => e.AssetDisposeId == id, ct);

            if (entity == null)
            {
                return false;
            }
            _dbContext.AssetDisposals.Remove(entity);

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

        public async Task<IEnumerable<AssetDisposeEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.AssetDisposals.AsNoTracking().Include(e=>e.Asset).ToListAsync(ct);
        }

        public async Task<AssetDisposeEntity?> GetByIdAsync(int id)
        {
          
            return await _dbContext.AssetDisposals
                .FirstOrDefaultAsync(e => e.AssetDisposeId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            AssetDisposeEntity assetDispose,
            CancellationToken ct = default)
        {
        
            if (assetDispose == null)
            {
                return false;
            }

            if (assetDispose.AssetDisposeId != id)
            {
                return false;
            }

            var existing = await _dbContext.AssetDisposals
                .FirstOrDefaultAsync(e => e.AssetDisposeId == id, ct);

            if (existing == null)
            {
                return false;
            }

            _dbContext.AssetDisposals.Update(assetDispose);

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