using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class AssetEventHistoryRepository(AssetTrackingDbContext _dbContext) : IAssetEventHistoryRepository
    {
        public async Task<AssetEventHistoryEntity?> AddAsync(
            AssetEventHistoryEntity assetEventHistoryEntity,
            CancellationToken ct = default)
        {
            if (assetEventHistoryEntity == null)
            {
                throw new ArgumentNullException(nameof(assetEventHistoryEntity));
            }

            try
            {
                await _dbContext.AssetEventHistories.AddAsync(assetEventHistoryEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return assetEventHistoryEntity;
            }
            catch (DbUpdateException ex)
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

            var entity = await _dbContext.AssetEventHistories
                .FirstOrDefaultAsync(e => e.AssetEventHistoryId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.AssetEventHistories.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AssetEventHistoryEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.AssetEventHistories
                            .AsNoTracking()
                            .Include(e => e.Asset)
                            .ToListAsync(ct);

        }

        public async Task<AssetEventHistoryEntity?> GetByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return await _dbContext.AssetEventHistories
                .FirstOrDefaultAsync(e => e.AssetEventHistoryId == id);
        }

        public async Task<bool> UpdateAsync(
            string id,
            AssetEventHistoryEntity assetEventHistoryEntity,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            if (assetEventHistoryEntity == null)
            {
                throw new ArgumentNullException(nameof(assetEventHistoryEntity));
            }

            if (assetEventHistoryEntity.AssetEventHistoryId != id)
            {
                return false;
            }

            var existing = await _dbContext.AssetEventHistories
                .FirstOrDefaultAsync(e => e.AssetEventHistoryId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.AssetEventHistories.Update(existing);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException ex)
            {
                return false;
            }
        }
    }
}