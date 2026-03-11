using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{


    public record DeleteSiteCommand(int SiteId) : IRequest<bool>;
    public class DeleteSiteHandler(ISiteRepository siteRepository) : IRequestHandler<DeleteSiteCommand, bool>
    {
        public async Task<bool> Handle(DeleteSiteCommand request, CancellationToken cancellationToken)
        {

            var roomExist = await siteRepository.GetByIdAsync(request.SiteId);
            if (roomExist == null) return false;
            return await siteRepository.DeleteAsync(request.SiteId, cancellationToken);

        }
    }
}
