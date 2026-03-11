using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Application.Common.Site;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Queries
{
    public record GetSiteHeadByIdQuery(int SiteHeadId)
     : IRequest<SiteHeadResponseDto>;

    public class GetSiteHeadByIdHandler(ISiteHeadRepository siteHeadRepository)
       : IRequestHandler<GetSiteHeadByIdQuery, SiteHeadResponseDto>
    {
        public async Task<SiteHeadResponseDto> Handle(
            GetSiteHeadByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await siteHeadRepository.GetByIdAsync(request.SiteHeadId)
                ?? throw new KeyNotFoundException("Site head not found.");

            return new SiteHeadResponseDto
            {
                SiteheadId = entity.SiteheadId,
                HeadName = entity.HeadName,
                HeadEmail = entity.HeadEmail,
                HeadPhoneNumber = entity.HeadPhoneNumber,
                TitleId = entity.TitleId
            };
        }
    }
}
