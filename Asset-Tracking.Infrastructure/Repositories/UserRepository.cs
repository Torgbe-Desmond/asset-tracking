using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using Asset_Tracking.Infrastructure.Persistence.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Asset_Tracking.Infrastructure.Repositories
{
    public class UserRepository(AssetTrackingDbContext dbContext) : IUserRepository
    {
        public async Task<UserEntity?> AddAsync(UserEntity userEntity, CancellationToken ct = default)
        {
            if (userEntity == null) return null;
            await dbContext.Users.AddAsync(userEntity, ct);
            await dbContext.SaveChangesAsync(ct);
            return userEntity;
        }

        public async Task<bool?> DeleteAsync(string id, CancellationToken ct = default)
        {
            var userEntity = await dbContext.Users.FirstOrDefaultAsync(u=>u.Id == id);
            if (userEntity == null) return false;
            dbContext.Users.Remove(userEntity);
            await dbContext.SaveChangesAsync(ct);
            return true;
        }

        public async Task<IEnumerable<UserEntity>> GetAllAsync(CancellationToken ct = default)
        {
           return await dbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<UserEntity?> GetByEmailAsync(string email)
        {
            return await dbContext.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<UserEntity?> GetByIdAsync(string id)
        {
            return await dbContext.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.Id == id);
        }
     
        public async Task<UserEntity?> UpdateAsync(string id,UserEntity userEntity, CancellationToken ct = default)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(user == null) return null;   
            dbContext.Users.Update(userEntity);

            try
            {
                await dbContext.SaveChangesAsync(ct);
                return userEntity;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }
    }
}
