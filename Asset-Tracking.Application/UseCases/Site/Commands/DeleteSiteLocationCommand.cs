using MediatR;

namespace Asset_Tracking.Application.UseCases.Site.Commands
{
    public record DeleteSiteLocationCommand(int SiteHeadId) : IRequest<bool>;
    public class DeleteSiteLocationHandler(Domain.Interfaces.ISiteLocationRepository siteLocationRepository) : IRequestHandler<DeleteSiteLocationCommand, bool>
    {
        public async Task<bool> Handle(DeleteSiteLocationCommand request, CancellationToken cancellationToken)
        {

            var sitetLocationExist = await siteLocationRepository.GetByIdAsync(request.SiteHeadId);
            if (sitetLocationExist == null) return false;
            return await siteLocationRepository.DeleteAsync(request.SiteHeadId, cancellationToken);

        }
    }
}
