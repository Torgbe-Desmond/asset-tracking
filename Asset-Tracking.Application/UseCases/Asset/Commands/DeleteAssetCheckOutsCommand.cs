using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record DeleteAssetCheckOutsCommand(int assetCheckOutId) : IRequest<bool>;

    public class DeleteAssetChecOutsHandler(IAssetCheckOutRepository assetCheckOutRepository) : IRequestHandler<DeleteAssetCheckOutsCommand, bool>
    {
        public async Task<bool> Handle(DeleteAssetCheckOutsCommand request, CancellationToken cancellationToken)
        {

            var assetExist = await assetCheckOutRepository.GetByIdAsync(request.assetCheckOutId);
            if (assetExist == null) return false;
            return await assetCheckOutRepository.DeleteAsync(request.assetCheckOutId, cancellationToken);

        }
    }
}
