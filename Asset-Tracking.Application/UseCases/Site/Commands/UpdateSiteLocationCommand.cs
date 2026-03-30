using Asset_Tracking.Application.Common.Dtos.Site;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{
    public record UpdateSiteLocationCommand(
       int SiteLocationId,
       SiteLocationUpdateRequestDto SiteLocation)
       : IRequest<bool>;

    public class UpdateSiteLocationHandler(Domain.Interfaces.ISiteLocationRepository siteLocationRepository)
        : IRequestHandler<UpdateSiteLocationCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateSiteLocationCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.SiteLocation;

            var entity = await siteLocationRepository.GetByIdAsync(request.SiteLocationId)
                ?? throw new KeyNotFoundException("Site location not found.");

            if (!string.IsNullOrWhiteSpace(dto.Location))
                entity.Location = dto.Location.Trim();

            if (!string.IsNullOrWhiteSpace(dto.UpdatedBy))
                entity.UpdatedBy = dto.UpdatedBy.Trim();

            entity.DateUpdated = DateTime.UtcNow;

            return await siteLocationRepository.UpdateAsync(request.SiteLocationId,entity);

           
        }
    }
}
