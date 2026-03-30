using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{
    public record UpdateSiteHeadCommand(int SiteHeadId, SiteHeadUpdateRequestDto SiteHead)
         : IRequest<bool>;

    public class UpdateSiteHeadHandler(ISiteHeadRepository siteHeadRepository)
       : IRequestHandler<UpdateSiteHeadCommand, bool>
    {
        public async Task<bool> Handle(
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

            return await siteHeadRepository.UpdateAsync(request.SiteHeadId, entity);
        }
    }
}
