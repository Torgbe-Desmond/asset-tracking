using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface ISiteRepository
    {
        Task<SiteEntity?> AddAsync(SiteEntity siteEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, SiteEntity siteEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<SiteEntity?> GetByIdAsync(int id);
        Task<IEnumerable<SiteEntity>?> GetAllAsync(CancellationToken ct = default);

    }
}
