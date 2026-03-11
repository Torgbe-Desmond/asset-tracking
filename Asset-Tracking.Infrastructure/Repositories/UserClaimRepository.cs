using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class UserClaimRepository(AssetTrackingDbContext _dbContext) : IUserClaimRepository
    {

        public async Task<UserClaimsEntity?> AddAsync(
            UserClaimsEntity userClaimEntity,
            CancellationToken ct = default)
        {
            if (userClaimEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.UserClaims.AddAsync(userClaimEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return userClaimEntity;
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
       
            var entity = await _dbContext.UserClaims
                .FirstOrDefaultAsync(e => e.Id == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.UserClaims.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return true;
            }
        }

        public async Task<UserClaimsEntity?> GetByIdAsync(int id)
        {
    
            return await _dbContext.UserClaims
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<UserClaimsEntity?> UpdateAsync(
            int id,
            UserClaimsEntity userClaimEntity,
            CancellationToken ct = default)
        {
          
            if (userClaimEntity == null)
            {
                return null;
            }

            if (userClaimEntity.Id != id)
            {
                return null;
            }

            var existing = await _dbContext.UserClaims
                .FirstOrDefaultAsync(e => e.Id == id, ct);

            if (existing == null)
            {
                return null;
            }

            try
            {
                _dbContext.UserClaims.Update(userClaimEntity);
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