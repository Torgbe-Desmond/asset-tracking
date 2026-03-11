using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class UserTokenRepository(AssetTrackingDbContext dbContext) : IUserTokenRepository
    {
        private readonly AssetTrackingDbContext _dbContext = dbContext
            ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<UserTokenEntity?> AddAsync(
            UserTokenEntity userTokenEntity,
            CancellationToken ct = default)
        {
            if (userTokenEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.UserTokens.AddAsync(userTokenEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return userTokenEntity;
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

            var entity = await _dbContext.UserTokens
                .FirstOrDefaultAsync(e => e.UserId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.UserTokens.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<UserTokenEntity?> GetAsync(
         string userId,
         string loginProvider,
         string name)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("UserId is required.", nameof(userId));

            if (string.IsNullOrWhiteSpace(loginProvider))
                throw new ArgumentException("LoginProvider is required.", nameof(loginProvider));

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", nameof(name));

            return await _dbContext.UserTokens
                .FirstOrDefaultAsync(e =>
                    e.UserId == userId &&
                    e.LoginProvider == loginProvider &&
                    e.Name == name);
        }


        public async Task<UserTokenEntity?> UpdateAsync(
            string id,
            UserTokenEntity userTokenEntity,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            if (userTokenEntity == null)
            {
                return null;
            }

            if (userTokenEntity.UserId != id)
            {
                return null;
            }

            var existing = await _dbContext.UserTokens
                .FirstOrDefaultAsync(e => e.UserId == id, ct);

            if (existing == null)
            {
                return null;
            }

            try
            {
                _dbContext.UserTokens.Update(userTokenEntity);
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