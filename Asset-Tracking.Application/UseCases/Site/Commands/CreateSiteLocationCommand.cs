using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{
    public record CreateSiteLocationCommand(SiteLocationRequestDto SiteLocation)
        : IRequest<SiteLocationResponseDto>;

    public class CreateSiteLocationHandler(Domain.Interfaces.ISiteLocationRepository siteLocationRepository)
  : IRequestHandler<CreateSiteLocationCommand, SiteLocationResponseDto>
    {
        public async Task<SiteLocationResponseDto> Handle(
            CreateSiteLocationCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.SiteLocation;

            if (string.IsNullOrWhiteSpace(dto.Location))
                throw new ArgumentException("Location is required.");

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("CreatedBy is required.");

            var entity = new SiteLocationEntity
            {
                Location = dto.Location.Trim(),
                SiteId = dto.SiteId,
                CreatedBy = dto.CreatedBy.Trim(),
                DateCreated = DateTime.UtcNow
            };

            await siteLocationRepository.AddAsync(entity);

            return new SiteLocationResponseDto
            {
                SiteLocationId = entity.SiteLocationId,
                Location = entity.Location,
                SiteId = entity.SiteId
            };
        }
    }
}
