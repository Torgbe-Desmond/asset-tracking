using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record UpdateAssetStatusCommand(int AssetStatusId, AssetStatusRequestDto AssetStatus) : IRequest<AssetStatusResponseDto>;

    public class UpdateAssetStatusHandler(IAssetStatusRepository assetStatusRepository) : IRequestHandler<UpdateAssetStatusCommand, AssetStatusResponseDto>
    {
        public async Task<AssetStatusResponseDto> Handle(UpdateAssetStatusCommand request, CancellationToken cancellationToken)
        {
            var dto = request.AssetStatus;

            if (string.IsNullOrWhiteSpace(dto.AssetStatusName))
                throw new ArgumentException("Status name is required.");

            var assetStatus = new AssetStatusEntity
            {
                AssetStatusName = dto.AssetStatusName.Trim(),
                CreatedBy = dto.CreatedBy.Trim(),
                DateCreated = DateTime.UtcNow,
                UpdatedBy = dto.UpdatedBy?.Trim(),
                DateUpdated = dto.DateUpdated
            };


            await assetStatusRepository.UpdateAsync(request.AssetStatusId, assetStatus);

            return new AssetStatusResponseDto
            {
                AssetStatusId = assetStatus.AssetStatusId,
                AssetStatusName = assetStatus.AssetStatusName,
                CreatedBy = assetStatus.CreatedBy,
                //DateCreated = assetStatus.DateCreated,
                UpdatedBy = assetStatus.UpdatedBy,
                //DateUpdated = assetStatus.DateUpdated
            };

        }
 
    }
}
