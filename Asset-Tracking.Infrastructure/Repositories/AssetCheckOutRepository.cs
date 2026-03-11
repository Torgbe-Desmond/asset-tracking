using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class AssetCheckOutRepository(AssetTrackingDbContext _dbContext) : IAssetCheckOutRepository
    {
        public async Task<AssetCheckOutEntity?> AddAsync(
            AssetCheckOutEntity roleEntity,
            CancellationToken ct = default)
        {
            if (roleEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.AssetCheckOuts.AddAsync(roleEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return roleEntity;
        }

        public async Task<bool> DeleteAsync(
            int id,
            CancellationToken ct = default)
        {
            if (id < 0)
            {
                return false;
            }

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
                return true;

            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AssetCheckOutEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.AssetCheckOuts
                     .AsNoTracking()
                     .Include(e => e.Asset)
                     .Include(e => e.Site)
                     .Include(e => e.Staff)
                     .ToListAsync();
        }

        public async Task<AssetCheckOutEntity?> GetByIdAsync(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return await _dbContext.AssetCheckOuts
                .FirstOrDefaultAsync(e => e.AssetCheckOutId == id);
        }

        public async Task<bool> UpdateAsync(
                   int id,
                   AssetCheckOutEntity assetCheckOutEntity,
                   CancellationToken ct = default)
        {
            if (id < 0)
            {
                return false;
            }

            if (assetCheckOutEntity == null)
            {
                return false;
            }

            var existing = await _dbContext.AssetCheckOuts
                .FirstOrDefaultAsync(e => e.AssetCheckOutId == id, ct);

            if (existing == null)
            {
                return false;
            }

            // Corrected the DbSet being updated to AssetCheckOuts
            _dbContext.AssetCheckOuts.Update(assetCheckOutEntity);

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

     
    }
}