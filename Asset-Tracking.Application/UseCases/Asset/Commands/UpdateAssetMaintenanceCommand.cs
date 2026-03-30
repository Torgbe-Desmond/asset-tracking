using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record UpdateAssetMaintenanceCommand(int AssetMaintenanceId ,AssetMaintenanceRequestDto AssetMaintenance) : IRequest<bool>;

    public class UpdateAssetMaintenanceHandler(IAssetMaintenanceRepository maintenanceRepository) : IRequestHandler<UpdateAssetMaintenanceCommand, bool>
    {
        public async Task<bool> Handle(UpdateAssetMaintenanceCommand request, CancellationToken cancellationToken)
        {
            var dto = request.AssetMaintenance;

            if (string.IsNullOrWhiteSpace(dto.MaintenanceTitle))
                throw new ArgumentException("Repair title is required.");

            if (dto.Cost < 0)
                throw new ArgumentException("Cost cannot be negative.");

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("Created by is required.");

            if (string.IsNullOrWhiteSpace(dto.Details))
                throw new ArgumentException("Asset details date is required.");

            if (string.IsNullOrWhiteSpace(dto.MaintainedBy))
                throw new ArgumentException("Asset MaintainedBy is required.");


            var maintenance = new AssetMaintenanceEntity()
            {
                MaintenanceTitle = dto.MaintenanceTitle.Trim(),
                Details = dto.Details.Trim(),
                DateSent = dto.DateSent,
                MaintainedBy = dto.MaintainedBy.Trim(),
                DateCompleted = dto.DateCompleted,
                Cost = dto.Cost,
                MaintenanceStatusId = dto.MaintenanceStatusId,
                AssetId = dto.AssetId,
                CreatedBy = dto.CreatedBy.Trim(),
                DateCreated = DateTime.UtcNow,
                UpdatedBy = dto.UpdatedBy?.Trim(),
                DateUpdated = dto.DateUpdated
            };

           return await maintenanceRepository.UpdateAsync(request.AssetMaintenanceId, maintenance);

        }


    }
}
