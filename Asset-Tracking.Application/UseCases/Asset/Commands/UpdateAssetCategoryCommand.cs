using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

public record UpdateAssetCategoryCommand(int AssetCategoryId, AssetCategoryRequestDto Category) : IRequest<bool>;

public class UpdateAssetCategoryHandler(IAssetCategoryRepository categoryRepository) : IRequestHandler<UpdateAssetCategoryCommand, bool>
{
   
    public async Task<bool> Handle(UpdateAssetCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await categoryRepository.GetByIdAsync(request.AssetCategoryId, cancellationToken);
        if (entity == null)
            throw new KeyNotFoundException($"AssetCategory with ID {request.AssetCategoryId} not found.");

        entity.AssetCategoryName = request.Category.AssetCategoryName.Trim();
        entity.UpdatedBy = request.Category.UpdatedBy.Trim();
        entity.DateUpdated = DateTime.UtcNow;

        return await categoryRepository.UpdateAsync(request.AssetCategoryId, entity, cancellationToken);

    }
}