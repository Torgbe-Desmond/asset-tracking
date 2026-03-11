using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record DeleteAssetCommand(int assetId) : IRequest<bool>;

    public class DeleteAssetHandler(IAssetRepository assetRepository) : IRequestHandler<DeleteAssetCommand, bool>
    {
        public async Task<bool> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
        {

            var assetExist = await assetRepository.GetByIdAsync(request.assetId);
            if (assetExist == null) return false;
            return await assetRepository.DeleteAsync(request.assetId, cancellationToken);

        }
    }
}
