using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAllAssetMaintenanceQuery() : IRequest<List<AssetMaintenanceResponseDto>>;

    public class GetAllAssetMaintenanceHandler(IAssetMaintenanceRepository maintenanceRepository) : IRequestHandler<GetAllAssetMaintenanceQuery, List<AssetMaintenanceResponseDto>>
    {
        public async Task<List<AssetMaintenanceResponseDto>> Handle(GetAllAssetMaintenanceQuery request, CancellationToken cancellationToken)
        {
        
           var assetMaintenances  =   await maintenanceRepository.GetAllAsync();

           var dtos = assetMaintenances.Select(assetMaintenance =>  new AssetMaintenanceResponseDto()
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
                //DateCreated = assetMaintenance.DateCreated,
                UpdatedBy = assetMaintenance.UpdatedBy,
                //DateUpdated = assetMaintenance.DateUpdated
            }).ToList();

            return dtos;

        }
    }
}
