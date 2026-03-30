using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Queries
{
    public record GetSiteByIdQuery(int SiteId) : IRequest<SiteResponseDto?>;

    public class GetSiteByIdHandler(ISiteRepository siteRepository) : IRequestHandler<GetSiteByIdQuery, SiteResponseDto?>
    {
        public async Task<SiteResponseDto?> Handle(
            GetSiteByIdQuery request,
            CancellationToken cancellationToken)
        {
       
            var entity = await siteRepository.GetByIdAsync(request.SiteId);

            if (entity == null) return null;

            return new SiteResponseDto
            {
                SiteId = entity.SiteId,
                SiteName = entity.SiteName,
                SiteDescription = entity.SiteDescription,
                Address = entity.Address,
                DigitalAddress = entity.DigitalAddress,
                Email = entity.Email,
                CreatedBy = entity.CreatedBy,
            };
        }
    }
}
