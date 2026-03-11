using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record DeleteAssetCategoryCommand(int AssetCategoryId) : IRequest<Unit>;

    public class DeleteAssetCategoryHandler(IAssetCategoryRepository assetCategoryRepository) : IRequestHandler<DeleteAssetCategoryCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteAssetCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await assetCategoryRepository.GetByIdAsync(request.AssetCategoryId, cancellationToken);
            if (entity == null)
            {
                throw new KeyNotFoundException($"AssetCategory with ID {request.AssetCategoryId} not found.");
            }

            await assetCategoryRepository.DeleteAsync(request.AssetCategoryId, cancellationToken);

            return Unit.Value;
        }
    }
}