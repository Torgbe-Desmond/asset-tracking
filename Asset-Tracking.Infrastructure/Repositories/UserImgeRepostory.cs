using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class UserImageRepository(AssetTrackingDbContext _dbContext) : IUserImageRepository
    {
        
        public async Task<UserImageEntity?> AddAsync(
            UserImageEntity userImageEntity,
            CancellationToken ct = default)
        {
            if (userImageEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.UserImages.AddAsync(userImageEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return userImageEntity;
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
       
            var entity = await _dbContext.UserImages
                .FirstOrDefaultAsync(e => e.Id == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.UserImages.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserImageEntity>> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.UserImages.AsNoTracking().ToListAsync();

        }

        public async Task<UserImageEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.UserImages
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<UserImageEntity?> UpdateAsync(
            int id,
            UserImageEntity userImageEntity,
            CancellationToken ct = default)
        {
        
            if (userImageEntity == null)
            {
                return null;
            }

            if (userImageEntity.Id != id)
            {
                return null;
            }

            var existing = await _dbContext.UserImages
                .FirstOrDefaultAsync(e => e.Id == id, ct);

            if (existing == null)
            {
                return null;
            }

            try
            {
                _dbContext.UserImages.Update(userImageEntity);
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