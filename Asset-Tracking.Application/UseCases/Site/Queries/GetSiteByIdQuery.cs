using Asset_Tracking.Application.Common.Site;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Queries
{
    public record GetSiteByIdQuery(int SiteId) : IRequest<SiteResponseDto>;

    public class GetSiteByIdHandler(ISiteRepository siteRepository) : IRequestHandler<GetSiteByIdQuery, SiteResponseDto>
    {
        public async Task<SiteResponseDto> Handle(
            GetSiteByIdQuery request,
            CancellationToken cancellationToken)
        {
            // Removed the null check for SiteId as it is not nullable (int type)
            if (request.SiteId <= 0)
                throw new ArgumentException("SiteId is required.", nameof(request.SiteId));

            var entity = await siteRepository.GetByIdAsync(request.SiteId);

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
