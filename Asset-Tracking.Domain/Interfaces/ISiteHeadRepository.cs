using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface ISiteHeadRepository
    {
        Task<SiteHeadEntity?> AddAsync(SiteHeadEntity siteHeadEntity, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, SiteHeadEntity siteHeadEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<SiteHeadEntity?> GetByIdAsync(int id);
        Task<IEnumerable<SiteHeadEntity>> GetAllAsync(CancellationToken ct = default);
    }
}
