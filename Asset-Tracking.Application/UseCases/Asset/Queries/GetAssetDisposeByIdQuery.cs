using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAssetDisposeByIdQuery(int AssetDisposeId)
      : IRequest<AssetDisposeResponseDto>;
    public class GetAssetDisposeByIdQueryHandler(IAssetDisposeRepository assetDisposeRepository)
    : IRequestHandler<GetAssetDisposeByIdQuery, AssetDisposeResponseDto>
    {
    
        public async Task<AssetDisposeResponseDto> Handle(
            GetAssetDisposeByIdQuery request,
            CancellationToken cancellationToken)
        {

            if (request.AssetDisposeId < 0)
                throw new ArgumentNullException("AssetDisposeId is required.", nameof(request.AssetDisposeId));

            var entity = await assetDisposeRepository.GetByIdAsync(request.AssetDisposeId);

            if (entity == null)
                throw new KeyNotFoundException("No aseet disposal found.");

            return new AssetDisposeResponseDto
            {
                AssetDisposeId = entity.AssetDisposeId,
                DisposeDate = entity.DisposeDate,
                DisposeTo = entity.DisposeTo,
                Notes = entity.Notes,
                //DateCreated = entity.DateCreated,
                CreatedBy = entity.CreatedBy,
                //DateUpdated = entity.DateUpdated,
                UpdatedBy = entity.UpdatedBy,
                AssetId = entity.AssetId
            };
        }
    }

}
