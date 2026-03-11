using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class AssetRepository(AssetTrackingDbContext _dbContext) : IAssetRepository
    {

        public async Task<AssetEntity?> CreateAsync(
            AssetEntity assEntity,
            CancellationToken ct = default)
        {
            if (assEntity == null)
            {
                return null;
            }

            try
            {
                var newAssetEntry = await _dbContext.Assets.AddAsync(assEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return newAssetEntry.Entity; 
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
          
            var entity = await _dbContext.Assets
                .FirstOrDefaultAsync(e => e.AssetId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.Assets.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public Task<bool> DeleteAsync(string id, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AssetEntity?>> GetAllAsync(CancellationToken ct = default)
        {
           return await _dbContext.Assets
               .AsNoTracking()
               .Include(a => a.AssetCategory)
               .Include(a => a.AssetStatus)
               .Include(a => a.Site)
               .Include(a => a.Building)
               .Include(a => a.Floor)
               .Include(a => a.Room)
               .Include(a => a.AssetImage)             
               .OrderBy(a => a.AssetName)
               .ToListAsync();
        }

        public async Task<AssetEntity?> GetByIdAsync(int id)
        {
      
            return await _dbContext.Assets
                 .AsNoTracking()
                 .Include(a => a.AssetCategory)
                 .Include(a => a.AssetStatus)
                 .Include(a => a.Site)
                 .Include(a => a.Building)
                 .Include(a => a.Floor)
                 .Include(a => a.Room)
                 .Include(a => a.AssetImage)
                 .FirstOrDefaultAsync(e => e.AssetId == id);
        }

        public async Task<AssetEntity?> GetByNameAsync(string assetName)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                return null;
            }
            return await _dbContext.Assets.FirstOrDefaultAsync(e => e.AssetName == assetName);
        }

        public async Task<AssetEntity?> GetByTagIdAsync(string tagId)
        {
            if (string.IsNullOrEmpty(tagId))
            {
                return null;
            }
            return await _dbContext.Assets.FirstOrDefaultAsync(e => e.AssetTagId == tagId);
        }

        public async Task<bool> UpdateAsync(
            int id,
            AssetEntity roleEntity,
            CancellationToken ct = default)
        {
       
            if (roleEntity == null)
            {
                return false;
            }

            if (roleEntity.AssetId != id)
            {
                return false;
            }

            var existing = await _dbContext.Assets
                .FirstOrDefaultAsync(e => e.AssetId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.Assets.Update(roleEntity);
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