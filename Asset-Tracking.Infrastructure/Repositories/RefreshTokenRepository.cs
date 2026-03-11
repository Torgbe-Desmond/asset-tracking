using System;
using System.Threading;
using System.Threading.Tasks;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    internal class RefreshTokenRepository(AssetTrackingDbContext _dbContext) : IRefreshTokenRepository
    {
       
        public async Task<RefreshTokenEntity?> AddAsync(
            RefreshTokenEntity refreshTokenEntity,
            CancellationToken ct = default)
        {
            try
            {
                await _dbContext.RefreshTokens.AddAsync(refreshTokenEntity, ct);
                await _dbContext.SaveChangesAsync(ct);
                return refreshTokenEntity;
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
         
            var entity = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(e => e.Id == id, ct);

            if (entity == null)
            {
                return false;
            }

            try
            {
                _dbContext.RefreshTokens.Remove(entity);
                await _dbContext.SaveChangesAsync(ct);
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public async Task<RefreshTokenEntity?> GetByIdAsync(int id)
        {
            return await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<RefreshTokenEntity?> UpdateAsync(
            int id,
            RefreshTokenEntity refreshTokenEntity,
            CancellationToken ct = default)
        {
         
            if (refreshTokenEntity == null)
            {
                return null;
            }

            if (refreshTokenEntity.Id != id)
            {
                return null;
            }

            var existing = await _dbContext.RefreshTokens
                .FirstOrDefaultAsync(e => e.Id == id, ct);

            if (existing == null)
            {
                return null;
            }

            
            try
            {
                _dbContext.RefreshTokens.Update(refreshTokenEntity);
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