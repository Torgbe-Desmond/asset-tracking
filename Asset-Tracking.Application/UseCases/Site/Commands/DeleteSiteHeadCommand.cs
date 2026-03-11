using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{
    public record DeleteSiteHeadCommand(int SiteHeadId) : IRequest<bool>;
    public class DeleteSiteHeadHandler(ISiteHeadRepository siteHeadRepository) : IRequestHandler<DeleteSiteHeadCommand, bool>
    {
        public async Task<bool> Handle(DeleteSiteHeadCommand request, CancellationToken cancellationToken)
        {

            var sietHeadExist = await siteHeadRepository.GetByIdAsync(request.SiteHeadId);
            if (sietHeadExist == null) return false;
            return await siteHeadRepository.DeleteAsync(request.SiteHeadId, cancellationToken);

        }
    }
}
