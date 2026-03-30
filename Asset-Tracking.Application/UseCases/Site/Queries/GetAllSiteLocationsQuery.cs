using Asset_Tracking.Application.Common.Dtos.Site;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Queries
{
    public record GetAllSiteLocationsQuery()
  : IRequest<List<SiteLocationResponseDto>>;

    public class GetAllSiteLocationsHandler(Domain.Interfaces.ISiteLocationRepository siteLocationRepository)
     : IRequestHandler<GetAllSiteLocationsQuery, List<SiteLocationResponseDto>>
    {
        public async Task<List<SiteLocationResponseDto>> Handle(
            GetAllSiteLocationsQuery request,
            CancellationToken cancellationToken)
        {
            var allSiteLocations = await siteLocationRepository.GetAllAsync(cancellationToken);

            var dtos = allSiteLocations.Select(allSiteLocation=> new SiteLocationResponseDto
            {
                SiteLocationId = allSiteLocation.SiteLocationId,
                Location = allSiteLocation.Location,
                SiteId = allSiteLocation.SiteId
            }).ToList();

            return dtos;
        }
    }
}
