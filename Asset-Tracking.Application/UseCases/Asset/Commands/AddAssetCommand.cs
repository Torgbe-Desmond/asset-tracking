using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddAssetCommand(AssetRequestDto Asset) : IRequest<AssetDetailResponseDto>;
    public class CreateAssetHandler(IAssetRepository assetRepository) : IRequestHandler<AddAssetCommand, AssetDetailResponseDto>
    {
        public async Task<AssetDetailResponseDto> Handle(AddAssetCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Asset;

            if (string.IsNullOrWhiteSpace(dto.AssetName))
                throw new ArgumentException("Asset name is required.");

            if (dto.Cost < 0)
                throw new ArgumentException("Cost cannot be negative.");

            if (string.IsNullOrWhiteSpace(dto.AssetTagId))
                throw new ArgumentException("Asset tag is required.");

            AssetEntity? assetAlreadyExists = await assetRepository.GetByNameAsync(dto.AssetName);
            if(assetAlreadyExists != null)
                throw new InvalidOperationException($"An asset with the name '{dto.AssetName}' already exists.");

            AssetEntity? assetTagAlreadyExists = await assetRepository.GetByTagIdAsync(dto.AssetTagId);

            if(assetTagAlreadyExists != null)
                throw new InvalidOperationException($"An asset with the tag ID '{dto.AssetTagId}' already exists.");


            AssetEntity? asset = new AssetEntity() {

                AssetName = dto.AssetName?.Trim(),

                AssetDescription = dto.AssetDescription?.Trim(),
                PurchaseFrom = dto.PurchaseFrom?.Trim(),
                PurchaseDate = dto.PurchaseDate,
                Cost = dto.Cost,
                Brand = dto.Brand?.Trim(),
                Model = dto.Model?.Trim(),
                SerialNumber = dto.SerialNumber?.Trim(),
                AssignedTo = dto.AssignedTo?.Trim(),

                HasWarranty = dto.HasWarranty,
                WarrantyDate = dto.WarrantyDate,

                AssetCategoryId = dto.AssetCategoryId,
                AssetStatusId = dto.AssetStatusId,
                AssetImageId = dto.AssetImageId,

                SiteId = dto.SiteId,
                BuildingId = dto.BuildingId,
                FloorId = dto.FloorId,
                RoomId = dto.RoomId,
                RoomLocationDescription = dto.RoomLocationDescription?.Trim(),

                AssetTagId = dto.AssetTagId?.Trim(),

                AssetConditionDescription = dto.AssetConditionDescription?.Trim(),
                IsAssetInGoodCondition = dto.IsAssetInGoodCondition,
                IsRepairRequired = dto.IsRepairRequired,

                DateCreated = DateTime.UtcNow,
                CreatedBy =  dto.CreatedBy,  
                DateUpdated = null,
                UpdatedBy = null

            };

            await assetRepository.CreateAsync(asset, cancellationToken);

            return new AssetDetailResponseDto()
            {
                AssetName = dto.AssetName?.Trim(),

                AssetDescription = asset.AssetDescription?.Trim(),
                PurchaseFrom = asset.PurchaseFrom?.Trim(),
                PurchaseDate = asset.PurchaseDate,
                Cost = asset.Cost,
                Brand = asset.Brand?.Trim(),
                Model = asset.Model?.Trim(),
                SerialNumber = asset.SerialNumber?.Trim(),
                AssignedTo = asset.AssignedTo?.Trim(),

                HasWarranty = asset.HasWarranty,
                WarrantyDate = asset.WarrantyDate,

                AssetCategoryId = asset.AssetCategoryId,
                AssetStatusId = asset.AssetStatusId,
                AssetImageId = asset.AssetImageId,

                SiteId = asset.SiteId,
                BuildingId = asset.BuildingId,
                FloorId = asset.FloorId,
                RoomId = asset.RoomId,
                RoomLocationDescription = asset.RoomLocationDescription?.Trim(),

                AssetTagId = asset.AssetTagId?.Trim(),

                AssetConditionDescription = asset.AssetConditionDescription?.Trim(),
                IsAssetInGoodCondition = asset.IsAssetInGoodCondition,
                IsRepairRequired = asset.IsRepairRequired,

                //DateCreated = asset.DateCreated,
                CreatedBy = asset.CreatedBy, 
                //DateUpdated = asset.DateUpdated,
                //UpdatedBy = asset.UpdatedBy,
            };
        }
    }
}
