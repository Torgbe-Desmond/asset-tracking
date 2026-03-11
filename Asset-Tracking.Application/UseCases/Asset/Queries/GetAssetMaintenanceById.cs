using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{

    public record GetAssetMaintenanceByIdQuery(int AssetMaintenanceId) : IRequest<AssetMaintenanceResponseDto>;

    public class GetAssetMaintenanceByIdHandler(IAssetMaintenanceRepository maintenanceRepository) : IRequestHandler<GetAssetMaintenanceByIdQuery, AssetMaintenanceResponseDto>
    {
        public async Task<AssetMaintenanceResponseDto> Handle(GetAssetMaintenanceByIdQuery request, CancellationToken cancellationToken)
        {

            if (request.AssetMaintenanceId < 0)
                throw new ArgumentNullException("AssetMaintenanceId is required.", nameof(request.AssetMaintenanceId));

            var assetMaintenance = await maintenanceRepository.GetByIdAsync(request.AssetMaintenanceId);

            if (assetMaintenance == null)
                throw new KeyNotFoundException("No asset maintenance data found.");


            return new AssetMaintenanceResponseDto()
            {
                AssetId = assetMaintenance.AssetId,
                MaintenanceTitle = assetMaintenance.MaintenanceTitle,
                Details = assetMaintenance.Details,
                DateSent = assetMaintenance.DateSent,
                MaintainedBy = assetMaintenance.MaintainedBy,
                DateCompleted = assetMaintenance.DateCompleted,
                Cost = assetMaintenance.Cost,
                MaintenanceStatusId = assetMaintenance.MaintenanceStatusId,
                CreatedBy = assetMaintenance.CreatedBy,
                UpdatedBy = assetMaintenance.UpdatedBy,

                MaintenanceStatus = assetMaintenance.MaintenanceStatus != null ? new MaintenanceStatusResponseDto 
                {

                    MaintenanceStatusId = assetMaintenance.MaintenanceStatus.MaintenanceStatusId,
                    StatusName = assetMaintenance.MaintenanceStatus.StatusName,
                    CreatedBy = assetMaintenance.MaintenanceStatus.CreatedBy,
                    UpdatedBy = assetMaintenance.MaintenanceStatus.UpdatedBy,
               
                } : null,

                Asset = assetMaintenance.Asset != null ? new AssetDto
                {
                    AssetId = assetMaintenance.Asset.AssetId,
                    AssetName = assetMaintenance.Asset.AssetName ?? string.Empty,
                    AssetDescription = assetMaintenance.Asset.AssetDescription,
                    PurchaseFrom = assetMaintenance.Asset.PurchaseFrom,
                    PurchaseDate = assetMaintenance.Asset.PurchaseDate,
                    Cost = assetMaintenance.Asset.Cost,
                    Brand = assetMaintenance.Asset.Brand,
                    Model = assetMaintenance.Asset.Model,
                    SerialNumber = assetMaintenance.Asset.SerialNumber,
                    AssignedTo = assetMaintenance.Asset.AssignedTo,
                    HasWarranty = assetMaintenance.Asset.HasWarranty,
                    WarrantyDate = assetMaintenance.Asset.WarrantyDate,
                    AssetCategoryId = assetMaintenance.Asset.AssetId,
                    AssetStatusId = assetMaintenance.Asset.AssetId,
                    AssetImageId = assetMaintenance.Asset.AssetId,
                    SiteId = assetMaintenance.Asset.AssetId,
                    BuildingId = assetMaintenance.Asset.AssetId,
                    FloorId = assetMaintenance.Asset.FloorId,
                    RoomId = assetMaintenance.Asset.AssetId,
                    RoomLocationDescription = assetMaintenance.Asset.RoomLocationDescription,
                    AssetTagId = assetMaintenance.Asset.AssetTagId ?? string.Empty,
                    AssetConditionDescription = assetMaintenance.Asset.AssetConditionDescription,
                    IsAssetInGoodCondition = assetMaintenance.Asset.IsAssetInGoodCondition,
                    IsRepairRequired = assetMaintenance.Asset.IsRepairRequired,
                    CreatedBy = assetMaintenance.Asset.CreatedBy,
                } : null,
            };
        }

      
    }
}
