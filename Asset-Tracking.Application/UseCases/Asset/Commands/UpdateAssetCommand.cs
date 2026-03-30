using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record UpdateAssetCommand(int AssetId,AssetRequestDto Asset) : IRequest<bool>;

    public class UpdateAssetHandler(IAssetRepository assetRepository): IRequestHandler<UpdateAssetCommand, bool>
    {
        public async Task<bool> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Asset;

            if (string.IsNullOrWhiteSpace(dto.AssetName))
                throw new ArgumentException("Asset name is required.");

            if (dto.Cost < 0)
                throw new ArgumentException("Cost cannot be negative.");

            if (string.IsNullOrWhiteSpace(dto.AssetTagId))
                throw new ArgumentException("Asset tag is required.");

            AssetEntity? assetAlreadyExists = await assetRepository.GetByNameAsync(dto.AssetName);
            if (assetAlreadyExists != null)
                throw new InvalidOperationException($"An asset with the name '{dto.AssetName}' already exists.");


            AssetEntity? assetExists = await assetRepository.GetByIdAsync(request.AssetId);
            if (assetExists != null)
                throw new InvalidOperationException($"Asset already exists.");

            AssetEntity? assetTagAlreadyExists = await assetRepository.GetByTagIdAsync(dto.AssetTagId);

            if (assetTagAlreadyExists != null)
                throw new InvalidOperationException($"An asset with the tag ID '{dto.AssetTagId}' already exists.");


            AssetEntity? asset = new AssetEntity()
            {

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

                DateCreated =  dto.DateCreated,
                CreatedBy = dto.CreatedBy,
                DateUpdated = DateTime.Now,
                UpdatedBy = dto.UpdatedBy

            };

            return await assetRepository.UpdateAsync(request.AssetId, asset, cancellationToken);

         
        }   
    }

}
