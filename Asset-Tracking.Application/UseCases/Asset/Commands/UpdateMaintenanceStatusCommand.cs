using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record UpdateMaintenanceStatusCommand(
        int MaintenanceStatusId,
        MaintenanceStatusRequestDto Dto
    ) : IRequest<bool>;

    public class UpdateMaintenanceStatusCommandHandler(IMaintenanceStatusRepository maintenanceStatus) : IRequestHandler<UpdateMaintenanceStatusCommand, bool>
    {
        public async Task<bool> Handle(
            UpdateMaintenanceStatusCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await maintenanceStatus.GetByIdAsync(request.MaintenanceStatusId)
                ?? throw new KeyNotFoundException("Maintenance status not found.");

            var dto = request.Dto;

            if (string.IsNullOrWhiteSpace(dto.StatusName))
                throw new ArgumentException("Status name is required.");

            entity.StatusName = dto.StatusName.Trim();
            entity.UpdatedBy = dto.UpdatedBy?.Trim();
            entity.DateUpdated = DateTime.UtcNow;

            return await maintenanceStatus.UpdateAsync(request.MaintenanceStatusId, entity);

        }
    }
}
