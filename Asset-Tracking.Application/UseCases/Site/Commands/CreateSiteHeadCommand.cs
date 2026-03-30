using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{
    public record CreateSiteHeadCommand(SiteHeadRequestDto SiteHead)
    : IRequest<SiteHeadResponseDto>;
    public class CreateSiteHeadHandler(ISiteHeadRepository siteHeadRepository)
        : IRequestHandler<CreateSiteHeadCommand, SiteHeadResponseDto>
    {
        public async Task<SiteHeadResponseDto> Handle(
            CreateSiteHeadCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.SiteHead;

            if (string.IsNullOrWhiteSpace(dto.HeadName))
                throw new ArgumentException("HeadName is required.");

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("CreatedBy is required.");

            var entity = new SiteHeadEntity
            {
                HeadName = dto.HeadName.Trim(),
                HeadEmail = dto.HeadEmail?.Trim(),
                HeadPhoneNumber = dto.HeadPhoneNumber?.Trim(),
                TitleId = dto.TitleId,
                CreatedBy = dto.CreatedBy.Trim(),
                DateCreated = DateTime.UtcNow
            };

            await siteHeadRepository.AddAsync(entity);

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
