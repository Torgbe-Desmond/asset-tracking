using System;
using System.Threading;
using System.Threading.Tasks;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class SiteRepository(AssetTrackingDbContext _dbContext) : ISiteRepository
    {

        public async Task<SiteEntity?> AddAsync(
            SiteEntity siteEntity,
            CancellationToken ct = default)
        {
            if (siteEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.Sites.AddAsync(siteEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return siteEntity;
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
            if (id < 0)
            {
                return false;
            }

            var entity = await _dbContext.Sites
                .FirstOrDefaultAsync(e => e.SiteId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.Sites.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SiteEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.Sites.AsNoTracking().Include(e=>e.SiteHead).ToListAsync();
        }

        public async Task<SiteEntity?> GetByIdAsync(int id)
        {
         
            return await _dbContext.Sites
                .FirstOrDefaultAsync(e => e.SiteId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            SiteEntity siteEntity,
            CancellationToken ct = default)
        {
        
            if (siteEntity == null)
            {
                return false;
            }

            if (siteEntity.SiteId != id)
            {
                return false;
            }

            var existing = await _dbContext.Sites
                .FirstOrDefaultAsync(e => e.SiteId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.Sites.Update(siteEntity);
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