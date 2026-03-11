using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    public class UserLoginRepository(AssetTrackingDbContext _dbContext) : IUserLoginRepository
    {
      
        public async Task<UserLoginEntity?> AddAsync(
            UserLoginEntity userLoginEntity,
            CancellationToken ct = default)
        {
            if (userLoginEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.UserLogins.AddAsync(userLoginEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return userLoginEntity;
            }
            catch (DbUpdateException)
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

            var entity = await _dbContext.UserLogins
                .FirstOrDefaultAsync(e => e.UserId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.UserLogins.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<UserLoginEntity?> GetByIdAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return await _dbContext.UserLogins
                .FirstOrDefaultAsync(e => e.UserId == id);
        }

        public async Task<UserLoginEntity?> UpdateAsync(
            string id,
            UserLoginEntity userLoginEntity,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            if (userLoginEntity == null)
            {
                return null;
            }

            if (userLoginEntity.UserId != id)
            {
                return null;
            }

            var existing = await _dbContext.UserLogins
                .FirstOrDefaultAsync(e => e.UserId == id, ct);

            if (existing == null)
            {
                return null;
            }

            try
            {
                _dbContext.UserLogins.Update(userLoginEntity);
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