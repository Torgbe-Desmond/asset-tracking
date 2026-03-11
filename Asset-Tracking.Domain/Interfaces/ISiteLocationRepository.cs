using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface ISiteLocationRepository
    {
        Task<SiteLocationEntity?> AddAsync(SiteLocationEntity siteLocationEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, SiteLocationEntity siteLocationEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<SiteLocationEntity?> GetByIdAsync(int id);

        Task<IEnumerable<SiteLocationEntity>> GetAllAsync(CancellationToken ct = default);
    }
}
