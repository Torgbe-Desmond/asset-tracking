using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class SiteHeadRepository(AssetTrackingDbContext _dbContext) : ISiteHeadRepository
    {

        public async Task<SiteHeadEntity?> AddAsync(
            SiteHeadEntity siteHeadEntity,
            CancellationToken ct = default)
        {
            if (siteHeadEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.SiteHeads.AddAsync(siteHeadEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return siteHeadEntity;
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
   
            var entity = await _dbContext.SiteHeads
                .FirstOrDefaultAsync(e => e.SiteheadId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.SiteHeads.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SiteHeadEntity>> GetAllAsync(CancellationToken ct = default)
        {
           return await  _dbContext.SiteHeads.AsNoTracking().Include(e=>e.Title).ToListAsync();
        }

        public async Task<SiteHeadEntity?> GetByIdAsync(int id)
        {
      
            return await _dbContext.SiteHeads
                .FirstOrDefaultAsync(e => e.SiteheadId == id);
        }

        public async Task<bool> UpdateAsync(
            int id,
            SiteHeadEntity siteHeadEntity,
            CancellationToken ct = default)
        {
      
            if (siteHeadEntity == null)
            {
                return false;
            }

            if (siteHeadEntity.SiteheadId != id)
            {
                return false;
            }

            var existing = await _dbContext.SiteHeads
                .FirstOrDefaultAsync(e => e.SiteheadId == id, ct);

            if (existing == null)
            {
                return false;
            }

            try
            {
                _dbContext.SiteHeads.Update(siteHeadEntity);
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