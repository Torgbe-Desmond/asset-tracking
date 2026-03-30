using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{

    public record GetMaintenanceStatusByIdQuery(int MaintenanceStatusId) : IRequest<MaintenanceStatusResponseDto?>;

    public class GetMaintenanceStatusByIdHandler(IMaintenanceStatusRepository maintenanceStatus) : IRequestHandler<GetMaintenanceStatusByIdQuery, MaintenanceStatusResponseDto?>
    {
        public async Task<MaintenanceStatusResponseDto?> Handle(
            GetMaintenanceStatusByIdQuery request,
            CancellationToken cancellationToken)
        {

            var status = await maintenanceStatus.GetByIdAsync(request.MaintenanceStatusId);

            if (status == null) return null;

            return new MaintenanceStatusResponseDto
            {
                MaintenanceStatusId = status.MaintenanceStatusId,
                StatusName = status.StatusName,
                CreatedBy = status.CreatedBy,
                UpdatedBy = status.UpdatedBy,
            };
        }
    }
}
