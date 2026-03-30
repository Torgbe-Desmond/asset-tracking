using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class SiteLocationRepository(AssetTrackingDbContext _dbContext) : ISiteLocationRepository
    {
        public async Task<SiteLocationEntity?> AddAsync(
            SiteLocationEntity siteLocationEntity,
            CancellationToken ct = default)
        {
            if (siteLocationEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.SiteLocations.AddAsync(siteLocationEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return siteLocationEntity;
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
        
            var entity = await _dbContext.SiteLocations
                .FirstOrDefaultAsync(e => e.SiteLocationId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.SiteLocations.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SiteLocationEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.SiteLocations.AsNoTracking().Include(e=>e.Site)
                .ToListAsync(ct);
        }
    
        public async Task<SiteLocationEntity?> GetByIdAsync(int id)
        {

            return await _dbContext.SiteLocations
                .FirstOrDefaultAsync(e => e.SiteLocationId == id);
        }
        
        public async Task<bool> UpdateAsync(
            int id,
            SiteLocationEntity roleEntity,
            CancellationToken ct = default)
        {
         
            if (roleEntity == null)
            {
                return false;
            }

            if (roleEntity.SiteLocationId != id)
            {
                return false;
            }

            var existing = await _dbContext.SiteLocations
                .FirstOrDefaultAsync(e => e.SiteLocationId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.SiteLocations.Update(roleEntity);
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