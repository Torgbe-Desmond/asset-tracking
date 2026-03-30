using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Queries
{

    public record GetAllSitesQuery() : IRequest<List<SiteResponseDto>>;

    public class GetAllSitesHandler(ISiteRepository siteRepository) : IRequestHandler<GetAllSitesQuery, List<SiteResponseDto>>
    {
        public async Task<List<SiteResponseDto>> Handle(
            GetAllSitesQuery request,
            CancellationToken cancellationToken)
        {
           
            var allSites = await siteRepository.GetAllAsync();

            var dtos = allSites.Select(allSite =>  new SiteResponseDto
            {
                SiteId = allSite.SiteId,
                SiteName = allSite.SiteName,
                SiteDescription = allSite.SiteDescription,
                Address = allSite.Address,
                DigitalAddress = allSite.DigitalAddress,
                Email = allSite.Email,
                //DateCreated = allSite.DateCreated,
                CreatedBy = allSite.CreatedBy,
            }).ToList();

            return dtos;
        }
    }
}
