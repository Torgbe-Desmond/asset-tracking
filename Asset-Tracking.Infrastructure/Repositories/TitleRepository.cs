using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class TitleRepository(AssetTrackingDbContext _dbContext) : ITitleRepository
    {
 
        public async Task<TitleEntity?> AddAsync(
            TitleEntity titleEntity,
            CancellationToken ct = default)
        {
            if (titleEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.Titles.AddAsync(titleEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return titleEntity;
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
       
            var entity = await _dbContext.Titles
                .FirstOrDefaultAsync(e => e.TitleId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.Titles.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<TitleEntity?> GetByIdAsync(int id)
        {
       
            return await _dbContext.Titles
                .FirstOrDefaultAsync(e => e.TitleId == id);
        }

        public async Task<TitleEntity?> UpdateAsync(
            int id,
            TitleEntity roleEntity,
            CancellationToken ct = default)
        {
      
            if (roleEntity == null)
            {
                return null;
            }

            if (roleEntity.TitleId != id)
            {
                return null;
            }

            var existing = await _dbContext.Titles
                .FirstOrDefaultAsync(e => e.TitleId == id, ct);

            if (existing == null)
            {
                return null;
            }

            try
            {
                _dbContext.Titles.Update(roleEntity);
                await _dbContext.SaveChangesAsync(ct);
                return existing;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }
    }
}