using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAssetRepairByIdQuery(int AssetRepairId) : IRequest<AssetRepairDetailResponseDto?>;
    public class GetAssetRepairByIdHandler(IAssetRepairRepository assetRepairRepository) : IRequestHandler<GetAssetRepairByIdQuery, AssetRepairDetailResponseDto?>
    {
        public async Task<AssetRepairDetailResponseDto?> Handle(GetAssetRepairByIdQuery request, CancellationToken cancellationToken)
        {

            if (request.AssetRepairId < 0)
                throw new ArgumentNullException("AssetRepairId is required.", nameof(request.AssetRepairId));

            var assetRepair = await assetRepairRepository.GetByIdAsync(request.AssetRepairId);

            if (assetRepair == null) return null;

            return new AssetRepairDetailResponseDto()
            {
                AssetRepairId = assetRepair.AssetRepairId,
                RepairTitle = assetRepair.RepairTitle.Trim(),
                Details = assetRepair.Details.Trim(),
                RepairerName = assetRepair.RepairerName?.Trim(),
                RepairerContactNumber = assetRepair.RepairerContactNumber?.Trim(),
                Cost = assetRepair.Cost,
                DateCompleted = assetRepair.DateCompleted?.Trim(),
                RepairStatusId = assetRepair.RepairStatusId,
                AssetReceiveDate = assetRepair.AssetReceiveDate,
                ReceivedBy = assetRepair.ReceivedBy?.Trim(),
                CreatedBy = assetRepair.CreatedBy,
                UpdateBy = assetRepair.UpdateBy,

                RepairStatus = assetRepair.RepairStatus != null ? new RepairStatusResponseDto
                {
                    RepairStatusId = assetRepair.RepairStatus.RepairStatusId,
                    RepairStatusName = assetRepair.RepairStatus.RepairStatusName,
                } : null,

                Asset = assetRepair.Asset != null ? new AssetDto
                {
                    AssetId = assetRepair.Asset.AssetId,
                    AssetName = assetRepair.Asset.AssetName ?? string.Empty,
                    AssetDescription = assetRepair.Asset.AssetDescription,
                    PurchaseFrom = assetRepair.Asset.PurchaseFrom,
                    PurchaseDate = assetRepair.Asset.PurchaseDate,
                    Cost = assetRepair.Asset.Cost,
                    Brand = assetRepair.Asset.Brand,
                    Model = assetRepair.Asset.Model,
                    SerialNumber = assetRepair.Asset.SerialNumber,
                    AssignedTo = assetRepair.Asset.AssignedTo,
                    HasWarranty = assetRepair.Asset.HasWarranty,
                    WarrantyDate = assetRepair.Asset.WarrantyDate,
                    AssetCategoryId = assetRepair.Asset.AssetId,
                    AssetStatusId = assetRepair.Asset.AssetId,
                    AssetImageId = assetRepair.Asset.AssetId,
                    SiteId = assetRepair.Asset.AssetId,
                    BuildingId = assetRepair.Asset.AssetId,
                    FloorId = assetRepair.Asset.FloorId,
                    RoomId = assetRepair.Asset.AssetId,
                    RoomLocationDescription = assetRepair.Asset.RoomLocationDescription,
                    AssetTagId = assetRepair.Asset.AssetTagId ?? string.Empty,
                    AssetConditionDescription = assetRepair.Asset.AssetConditionDescription,
                    IsAssetInGoodCondition = assetRepair.Asset.IsAssetInGoodCondition,
                    IsRepairRequired = assetRepair.Asset.IsRepairRequired,
                    CreatedBy = assetRepair.Asset.CreatedBy,
                } : null,
            };
        }

    
    }
}
