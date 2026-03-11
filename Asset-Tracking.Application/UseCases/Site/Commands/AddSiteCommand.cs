using Asset_Tracking.Application.Common.Site;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{
    public record AddSiteCommand(SiteRequestDto Site) : IRequest<SiteResponseDto>;

    public class AddSiteCommandHandler(ISiteRepository siteRepository) : IRequestHandler<AddSiteCommand, SiteResponseDto>
    {
        public async Task<SiteResponseDto> Handle(
            AddSiteCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.Site;

            if (string.IsNullOrWhiteSpace(dto.SiteName))
                throw new ArgumentException("SiteName is required.", nameof(dto.SiteName));

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("CreatedBy is required.", nameof(dto.CreatedBy));

            var entity = new SiteEntity
            {
                SiteName = dto.SiteName.Trim(),
                SiteDescription = dto.SiteDescription?.Trim(),
                Address = dto.Address?.Trim(),
                DigitalAddress = dto.DigitalAddress?.Trim(),
                Email = dto.Email?.Trim(),
                DateCreated = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy.Trim()
            };

            await siteRepository.AddAsync(entity, cancellationToken);

            return new SiteResponseDto
            {
                SiteId = entity.SiteId,
                SiteName = entity.SiteName,
                SiteDescription = entity.SiteDescription,
                Address = entity.Address,
                DigitalAddress = entity.DigitalAddress,
                Email = entity.Email,
                //DateCreated = entity.DateCreated,
                CreatedBy = entity.CreatedBy,
            };
        }
    }
}
