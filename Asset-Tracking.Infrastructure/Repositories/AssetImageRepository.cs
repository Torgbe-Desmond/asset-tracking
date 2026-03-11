using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class AssetImageRepository(AssetTrackingDbContext _dbContext) : IAssetImageRepository
    {
       

        public async Task<AssetImageEntity?> AddAsync(
            AssetImageEntity roleEntity,
            CancellationToken ct = default)
        {
            if (roleEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.AssetImages.AddAsync(roleEntity, ct);
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
        
            var entity = await _dbContext.AssetImages
                .FirstOrDefaultAsync(e => e.AssetImageId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.AssetImages.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AssetImageEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.AssetImages.ToListAsync(ct);
        }

        public async Task<AssetImageEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.AssetImages
                .FirstOrDefaultAsync(e => e.AssetImageId == id, ct);
        }

        public async Task<bool> UpdateAsync(
            int id,
            AssetImageEntity assetImageEntity,
            CancellationToken ct = default)
        {

            if (assetImageEntity == null)
            {
                return false;
            }

            if (assetImageEntity.AssetImageId != id)
            {
                return false;
            }

            var existing = await _dbContext.AssetImages
                .FirstOrDefaultAsync(e => e.AssetImageId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.AssetImages.Update(existing);
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