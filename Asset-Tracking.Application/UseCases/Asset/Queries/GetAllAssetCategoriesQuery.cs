using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAllAssetCategoriesQuery() : IRequest<List<AssetCategoryResponseDto>>;
    public class GetAllAssetCategoriesHandler(IAssetCategoryRepository categoryRepository) : IRequestHandler<GetAllAssetCategoriesQuery, List<AssetCategoryResponseDto>>
    {
        public async Task<List<AssetCategoryResponseDto>> Handle(GetAllAssetCategoriesQuery request, CancellationToken cancellationToken)
        {
         
            var categories =  await categoryRepository.GetAllAsync();

            var dtos = categories.Select(category => new AssetCategoryResponseDto
            {
                AssetCategoryId = category.AssetCategoryId,
                AssetCategoryName = category.AssetCategoryName,
                CreatedBy = category.CreatedBy,
                UpdatedBy = category.UpdatedBy
            }).ToList();

            return dtos;

        }

    }

}
