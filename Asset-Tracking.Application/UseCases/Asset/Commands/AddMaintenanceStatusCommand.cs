using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddMaintenanceStatusCommand(
     MaintenanceStatusRequestDto Dto
 ) : IRequest<MaintenanceStatusResponseDto>;


    public class AddMaintenanceStatusHandler(IMaintenanceStatusRepository maintenanceStatus) : IRequestHandler<AddMaintenanceStatusCommand, MaintenanceStatusResponseDto>
    {
        public async Task<MaintenanceStatusResponseDto> Handle(AddMaintenanceStatusCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            if (string.IsNullOrWhiteSpace(dto.StatusName))
                throw new ArgumentException("Status name is required.");
            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("Created by is required.");
   
            var maintenanceStatusEntity = new MaintenanceStatusEntity()
            {
                StatusName = request.Dto.StatusName.Trim(),
                CreatedBy = request.Dto.CreatedBy.Trim(),
                UpdatedBy = request.Dto.UpdatedBy?.Trim(),
                DateCreated= DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
            };

            await maintenanceStatus.AddAsync(maintenanceStatusEntity);

            return new MaintenanceStatusResponseDto()
            {
                MaintenanceStatusId = maintenanceStatusEntity.MaintenanceStatusId,
                StatusName = maintenanceStatusEntity.StatusName,
                CreatedBy = maintenanceStatusEntity.CreatedBy,
                UpdatedBy = maintenanceStatusEntity.UpdatedBy,
                //DateCreated = maintenanceStatusEntity.DateCreated,
                //DateUpdated = maintenanceStatusEntity.DateUpdated,
            };
        }
    }

}
