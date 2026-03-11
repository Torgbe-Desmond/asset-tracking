using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    public class RoleRepository(AssetTrackingDbContext dbContext) : IRoleRepository
    {
        public async Task<RoleEntity?> AddAsync(RoleEntity roleEntity, CancellationToken ct = default)
        {
            if (roleEntity == null) return null;

            await dbContext.Roles.AddAsync(roleEntity, ct);
            await dbContext.SaveChangesAsync(ct);

            return roleEntity;
        }

        public async Task<bool> DeleteAsync(string id, CancellationToken ct = default)
        {
            var role = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == id, ct);

            if (role == null) return false;

            dbContext.Roles.Remove(role);
            await dbContext.SaveChangesAsync(ct);

            return true;
        }

        public async Task<RoleEntity?> GetByIdAsync(string id, CancellationToken ct = default)
        {
            return await dbContext.Roles
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id,ct);
        }

        public async Task<IEnumerable<RoleEntity>> GetAllAsync()
        {
            return await dbContext.Roles
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(string id, RoleEntity roleEntity, CancellationToken ct = default)
        {
            var existing = await dbContext.Roles.FirstOrDefaultAsync(r => r.Id == id, ct);

            if (existing == null) return false;

            try
            {
                existing.Name = roleEntity.Name;
                existing.ConcurrencyStamp = roleEntity.ConcurrencyStamp;
                existing.NormalizedName = roleEntity.NormalizedName;

                await dbContext.SaveChangesAsync(ct);

                return true;
            }
            catch (DbUpdateException ex) {
                return false;
            }
        }

        public async Task<IEnumerable<RoleEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await dbContext.Roles.ToListAsync(ct);
        }
    }
}
