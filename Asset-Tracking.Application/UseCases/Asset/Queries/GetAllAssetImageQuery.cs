using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAllAssetImageQuery() : IRequest<List<AssetImageResponseDto>>;
    public class UpdateAssetImageHandler(IAssetImageRepository imageRepository) : IRequestHandler<GetAllAssetImageQuery, List<AssetImageResponseDto>>
    {
        public async Task<List<AssetImageResponseDto>> Handle(
            GetAllAssetImageQuery request,
            CancellationToken cancellationToken)
        {

            var images = await imageRepository.GetAllAsync(cancellationToken);

            var dtos = images.Select(image => new AssetImageResponseDto
            {
                AssetImageId = image.AssetImageId,
                Photo = image.Photo,

            }).ToList();

            return dtos;
        }
    }
}
