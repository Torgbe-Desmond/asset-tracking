using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Queries
{

    public record GetAllSiteHeadsQuery()
    : IRequest<List<SiteHeadResponseDto>>;

    public class GetAllSiteHeadsHandler(ISiteHeadRepository siteHeadRepository)
       : IRequestHandler<GetAllSiteHeadsQuery, List<SiteHeadResponseDto>>
    {
        public async Task<List<SiteHeadResponseDto>> Handle(
            GetAllSiteHeadsQuery request,
            CancellationToken cancellationToken)
        {
            var allSiteHeads = await siteHeadRepository.GetAllAsync();
               
            var dtos = allSiteHeads.Select(allSiteHead => new SiteHeadResponseDto
            {
                SiteheadId = allSiteHead.SiteheadId,
                HeadName = allSiteHead.HeadName,
                HeadEmail = allSiteHead.HeadEmail,
                HeadPhoneNumber = allSiteHead.HeadPhoneNumber,
                TitleId = allSiteHead.TitleId
            }).ToList();

            return dtos;
        }
    }
}
