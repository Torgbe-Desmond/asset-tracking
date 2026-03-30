using Asset_Tracking.Application.Common.Dtos.Site;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Queries
{
    public record GetSiteLocationByIdQuery(int SiteLocationId)
      : IRequest<SiteLocationResponseDto?>;

    public class GetSiteLocationByIdHandler(Domain.Interfaces.ISiteLocationRepository siteLocationRepository)
     : IRequestHandler<GetSiteLocationByIdQuery, SiteLocationResponseDto?>
    {
        public async Task<SiteLocationResponseDto?> Handle(
            GetSiteLocationByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await siteLocationRepository.GetByIdAsync(request.SiteLocationId);

            if (entity == null) return null;

            return new SiteLocationResponseDto
            {
                SiteLocationId = entity.SiteLocationId,
                Location = entity.Location,
                SiteId = entity.SiteId
            };
        }
    }


}
