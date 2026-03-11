using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record DeleteAssetMaintenanceStatusCommand(int MaintenanceStatusId) : IRequest<bool>;

    public class DeleteAssetMaintenanceStatusHandler(IMaintenanceStatusRepository maintenanceStatus) : IRequestHandler<DeleteAssetMaintenanceStatusCommand, bool>
    {
        public async Task<bool> Handle(DeleteAssetMaintenanceStatusCommand request, CancellationToken cancellationToken)
        {

            var assetMaintenaceStatusExist = await maintenanceStatus.GetByIdAsync(request.MaintenanceStatusId);
            if (assetMaintenaceStatusExist == null) return false;
            return await maintenanceStatus.DeleteAsync(request.MaintenanceStatusId, cancellationToken);

        }
    }
}
