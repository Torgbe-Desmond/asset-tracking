using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record DeleteAssetMaintenanceCommand(int AssetMaintenanceId) : IRequest<bool>;

    public class DeleteAssetMaintenanceHandler(IAssetMaintenanceRepository maintenanceRepository) : IRequestHandler<DeleteAssetMaintenanceCommand, bool>
    {
        public async Task<bool> Handle(DeleteAssetMaintenanceCommand request, CancellationToken cancellationToken)
        {

            var assetExist = await maintenanceRepository.GetByIdAsync(request.AssetMaintenanceId);
            if (assetExist == null) return false;
            return await maintenanceRepository.DeleteAsync(request.AssetMaintenanceId, cancellationToken);

        }
    }
}
