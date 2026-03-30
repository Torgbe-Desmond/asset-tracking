using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{
    public record UpdateSiteCommand(int SiteId, SiteRequestDto Site) : IRequest<bool>;

    public class UpdateSiteHandler(ISiteRepository siteRepository) : IRequestHandler<UpdateSiteCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateSiteCommand request,
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

            return await siteRepository.UpdateAsync(request.SiteId, entity, cancellationToken);  
        }
    }
}
