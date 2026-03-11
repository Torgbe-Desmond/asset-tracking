using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddAssetStatusCommand(AssetStatusRequestDto AssetStatus): IRequest<AssetStatusResponseDto>;


    public class AddAssetStatusHandler(IAssetStatusRepository assetStatusRepository) : IRequestHandler<AddAssetStatusCommand, AssetStatusResponseDto>
    {
        public async Task<AssetStatusResponseDto> Handle(AddAssetStatusCommand request, CancellationToken cancellationToken)
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


            await assetStatusRepository.AddAsync(assetStatus);

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