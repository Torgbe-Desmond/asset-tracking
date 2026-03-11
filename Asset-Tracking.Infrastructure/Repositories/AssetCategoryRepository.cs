using System;
using System.Threading;
using System.Threading.Tasks;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class AssetCategoryRepository(AssetTrackingDbContext dbContext) : IAssetCategoryRepository
    {
        private readonly AssetTrackingDbContext _dbContext = dbContext
            ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<AssetCategoryEntity?> AddAsync(
            AssetCategoryEntity assetCategoryEntity,
            CancellationToken ct = default)
        {
     
            if (assetCategoryEntity is null)
                return null;    

            try
            {
                await _dbContext.AssetCategories.AddAsync(assetCategoryEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return assetCategoryEntity;
        }

        public async Task<bool> DeleteAsync(
            int id,
            CancellationToken ct = default)
        {
           
            var entity = await _dbContext.AssetCategories
                .FirstOrDefaultAsync(e => e.AssetCategoryId == id, ct);

            if (entity is null) return false;

            _dbContext.AssetCategories.Remove(entity);

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

        public async Task<IEnumerable<AssetCategoryEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.AssetCategories.ToListAsync(ct);
        }

        public async Task<AssetCategoryEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbContext.AssetCategories
                .FirstOrDefaultAsync(e => e.AssetCategoryId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            AssetCategoryEntity roleEntity,
            CancellationToken ct = default)
        {
           
            if (roleEntity == null)
            {
                return false;
            }

            if (roleEntity.AssetCategoryId != id)
            {
                return true;
            }

            var existing = await _dbContext.AssetCategories
                .FirstOrDefaultAsync(e => e.AssetCategoryId == id, ct);

            if (existing == null)
            {
                return false;
            }

            existing.AssetCategoryName = roleEntity.AssetCategoryName;

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