using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAssetImageByIdQuery(int AssetImageId) : IRequest<AssetImageResponseDto>;
    public class GetAssetImageByIdHandler(IAssetImageRepository imageRepository) : IRequestHandler<GetAssetImageByIdQuery, AssetImageResponseDto>
    {
        public async Task<AssetImageResponseDto> Handle(
            GetAssetImageByIdQuery request,
            CancellationToken cancellationToken)
        {

            var image = await imageRepository.GetByIdAsync(request.AssetImageId, cancellationToken);

            return new AssetImageResponseDto
            {
                AssetImageId = image.AssetImageId,
                Photo = image.Photo,

            };

        }
    }
}
