using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAssetCategoryByIdQuery(int AssetCategoryId) : IRequest<AssetCategoryResponseDto>;
    public class GetAssetCategoryByIdHandler(IAssetCategoryRepository categoryRepository) : IRequestHandler<GetAssetCategoryByIdQuery, AssetCategoryResponseDto>
    {
        public async Task<AssetCategoryResponseDto> Handle(GetAssetCategoryByIdQuery request, CancellationToken cancellationToken)
        {

            var category = await categoryRepository.GetByIdAsync(request.AssetCategoryId);

            return new AssetCategoryResponseDto
            {
                AssetCategoryId = category.AssetCategoryId,
                AssetCategoryName = category.AssetCategoryName,
                CreatedBy = category.CreatedBy,
                UpdatedBy = category.UpdatedBy
            };
        }

    }
}
