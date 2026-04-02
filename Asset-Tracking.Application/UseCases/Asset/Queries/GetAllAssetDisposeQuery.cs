using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAllAssetDisposeQuery()
     : IRequest<List<AssetDisposeResponseDto>>;
    public class GetAllAssetDisposeQueryHandler(IAssetDisposeRepository assetDisposeRepository)
    : IRequestHandler<GetAllAssetDisposeQuery, List<AssetDisposeResponseDto>>
    {
        public async Task<List<AssetDisposeResponseDto>> Handle(
            GetAllAssetDisposeQuery request,
            CancellationToken cancellationToken)
        {

            var assetDisposes = await assetDisposeRepository.GetAllAsync();

            if (assetDisposes == null)
                throw new Exception("No aseet disposal found.");

            var dtos = assetDisposes.Select(assetDispose =>  new AssetDisposeResponseDto
            {
                AssetDisposeId = assetDispose.AssetDisposeId,
                DisposeDate = assetDispose.DisposeDate,
                DisposeTo = assetDispose.DisposeTo,
                Notes = assetDispose.Notes,
                CreatedBy = assetDispose.CreatedBy,
                UpdatedBy = assetDispose.UpdatedBy,
                AssetId = assetDispose.AssetId
            }).ToList();

            return dtos;
        }
    }
}
