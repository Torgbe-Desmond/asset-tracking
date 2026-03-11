using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class AssetStatusRepository(AssetTrackingDbContext _dbContext) : IAssetStatusRepository
    {
      
        public async Task<AssetStatusEntity?> AddAsync(
            AssetStatusEntity roleEntity,
            CancellationToken ct = default)
        {
            if (roleEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.AssetStatuses.AddAsync(roleEntity, ct);
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
       
            var entity = await _dbContext.AssetStatuses
                .FirstOrDefaultAsync(e => e.AssetStatusId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.AssetStatuses.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<AssetStatusEntity?> GetByIdAsync(int id)
        {
          
            return await _dbContext.AssetStatuses
                .FirstOrDefaultAsync(e => e.AssetStatusId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            AssetStatusEntity roleEntity,
            CancellationToken ct = default)
        {
       
            if (roleEntity == null)
            {
                return false;
            }

            if (roleEntity.AssetStatusId != id)
            {
                return false;
            }

            var existing = await _dbContext.AssetStatuses
                .FirstOrDefaultAsync(e => e.AssetStatusId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.AssetStatuses.Update(roleEntity);
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