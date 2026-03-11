using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    public class UserRolesRepository(AssetTrackingDbContext _dbContext) : IUserRolesRepository
    {
    
        public async Task<UserRolesEntity?> AddAsync(
            UserRolesEntity userRoleEntity,
            CancellationToken ct = default)
        {
            if (userRoleEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.UserRoles.AddAsync(userRoleEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return userRoleEntity;
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

            var entity = await _dbContext.UserRoles
                .FirstOrDefaultAsync(e => e.RoleId == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.UserRoles.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<UserRolesEntity?> GetAsync(string roleId, string userId)
        {
            if (string.IsNullOrWhiteSpace(roleId) || string.IsNullOrWhiteSpace(userId))
            {
                return null;
            }

            return await _dbContext.UserRoles
                .FirstOrDefaultAsync(e => (e.RoleId == roleId) && (e.UserId == userId));
        }

        public async Task<UserRolesEntity?> UpdateAsync(
            string id,
            UserRolesEntity userRoleEntity,
            CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            if (userRoleEntity == null)
            {
                return null;
            }

            if (userRoleEntity.RoleId != id)
            {
                return null;
            }

            var existing = await _dbContext.UserRoles
                .FirstOrDefaultAsync(e => e.RoleId == id, ct);

            if (existing == null)
            {
                return null;
            }

            try
            {
                _dbContext.UserRoles.Update(userRoleEntity);
                await _dbContext.SaveChangesAsync(ct);
                return existing;
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }
    }
}