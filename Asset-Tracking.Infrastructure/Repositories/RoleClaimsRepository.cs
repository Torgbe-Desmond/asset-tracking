using System;
using System.Threading;
using System.Threading.Tasks;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class RoleClaimsRepository(AssetTrackingDbContext _dbContext) : IRoleClaimsRepository
    {
        public async Task<RoleClaimsEntity?> AddAsync(
            RoleClaimsEntity roleclaimEntity,
            CancellationToken ct = default)
        {
            if (roleclaimEntity == null)
            {
                return null;
            }

            try
            {
                await _dbContext.RoleClaims.AddAsync(roleclaimEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return roleclaimEntity;
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
          

            var entity = await _dbContext.RoleClaims
                .FirstOrDefaultAsync(e => e.Id == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.RoleClaims.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<IEnumerable<RoleClaimsEntity>?> GetAllAsync(CancellationToken ct = default)
        {
            return await _dbContext.RoleClaims.ToListAsync(ct);
        }

        public async Task<RoleClaimsEntity?> GetByIdAsync(int id, CancellationToken ct = default)
        {

            return await _dbContext.RoleClaims
                .FirstOrDefaultAsync(e => e.Id == id ,ct);
        }

     
        public async Task<RoleClaimsEntity?> UpdateAsync(
            int id,
            RoleClaimsEntity roleclaimEntity,
            CancellationToken ct = default)
        {
         
            if (roleclaimEntity == null)
            {
                return null;
            }

            if (roleclaimEntity.Id != id)
            {
                return null;
            }

            var existing = await _dbContext.RoleClaims
                .FirstOrDefaultAsync(e => e.Id == id, ct);

            if (existing == null)
            {
                return null;
            }

            try
            {
                _dbContext.RoleClaims.Update(roleclaimEntity);
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