using Asset_Tracking.Application.Common.Site;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{
    public record UpdateSiteHeadCommand(int SiteHeadId, SiteHeadUpdateRequestDto SiteHead)
         : IRequest<SiteHeadResponseDto>;

    public class UpdateSiteHeadHandler(ISiteHeadRepository siteHeadRepository)
       : IRequestHandler<UpdateSiteHeadCommand, SiteHeadResponseDto>
    {
        public async Task<SiteHeadResponseDto> Handle(
            UpdateSiteHeadCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.SiteHead;

            var entity = await siteHeadRepository.GetByIdAsync(request.SiteHeadId)
                ?? throw new KeyNotFoundException("Site head not found.");

            if (!string.IsNullOrWhiteSpace(dto.HeadName))
                entity.HeadName = dto.HeadName.Trim();

            if (!string.IsNullOrWhiteSpace(dto.HeadEmail))
                entity.HeadEmail = dto.HeadEmail.Trim();

            if (!string.IsNullOrWhiteSpace(dto.HeadPhoneNumber))
                entity.HeadPhoneNumber = dto.HeadPhoneNumber.Trim();

            if (!string.IsNullOrWhiteSpace(dto.UpdatedBy))
                entity.UpdatedBy = dto.UpdatedBy.Trim();

            entity.DateUpdated = DateTime.UtcNow;

            await siteHeadRepository.UpdateAsync(request.SiteHeadId, entity);

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
