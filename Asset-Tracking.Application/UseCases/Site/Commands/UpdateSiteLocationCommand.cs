using Asset_Tracking.Application.Common.Site;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{
    public record UpdateSiteLocationCommand(
       int SiteLocationId,
       SiteLocationUpdateRequestDto SiteLocation)
       : IRequest<SiteLocationResponseDto>;

    public class UpdateSiteLocationHandler(Domain.Interfaces.ISiteLocationRepository siteLocationRepository)
        : IRequestHandler<UpdateSiteLocationCommand, SiteLocationResponseDto>
    {
        public async Task<SiteLocationResponseDto> Handle(
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

            await siteLocationRepository.UpdateAsync(request.SiteLocationId,entity);

            return new SiteLocationResponseDto
            {
                SiteLocationId = entity.SiteLocationId,
                Location = entity.Location,
                SiteId = entity.SiteId
            };
        }
    }
}
