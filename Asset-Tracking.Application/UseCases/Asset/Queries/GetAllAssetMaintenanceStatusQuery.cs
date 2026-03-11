using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{

    public record GetAllAssetMaintenanceStatusQuery() : IRequest<List<MaintenanceStatusResponseDto>>;

    public class GetAllAssetMaintenanceStatusHandler(IMaintenanceStatusRepository maintenanceStatus) : IRequestHandler<GetAllAssetMaintenanceStatusQuery, List<MaintenanceStatusResponseDto>>
    {
        public async Task<List<MaintenanceStatusResponseDto>> Handle(
            GetAllAssetMaintenanceStatusQuery request,
            CancellationToken cancellationToken)
        {
           
            var maintenanceStatuses = await maintenanceStatus.GetAllAsync(cancellationToken);

            var dtos = maintenanceStatuses.Select(maintenanceStatus=> new MaintenanceStatusResponseDto
            {
                MaintenanceStatusId = maintenanceStatus.MaintenanceStatusId,
                StatusName = maintenanceStatus.StatusName,
                CreatedBy = maintenanceStatus.CreatedBy,
                UpdatedBy = maintenanceStatus.UpdatedBy,
                //DateCreated = maintenanceStatus.DateCreated,
                //DateUpdated = maintenanceStatus.DateUpdated
            }).ToList();

            return dtos;
        }
    }
}
