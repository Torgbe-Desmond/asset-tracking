using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record DeleteAssetImageCommand(int AssetImageId) : IRequest<bool>;
    public class DeleteAssetImageHandler(IAssetImageRepository imageRepository) : IRequestHandler<DeleteAssetImageCommand, bool>
    {
        public async Task<bool> Handle(DeleteAssetImageCommand request, CancellationToken cancellationToken)
        {

            var assetExist = await imageRepository.GetByIdAsync(request.AssetImageId);
            if (assetExist == null) return false;
            return await imageRepository.DeleteAsync(request.AssetImageId, cancellationToken);

        }
    }
}
