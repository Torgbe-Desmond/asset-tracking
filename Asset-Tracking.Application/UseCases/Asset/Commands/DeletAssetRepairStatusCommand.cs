using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record DeletAssetRepairStatusCommand(int assetRepairId) : IRequest<bool>;

    public class DeletAssetRepairStatusHandler(IRepairStatusRepository repairStatusRepository) : IRequestHandler<DeletAssetRepairStatusCommand, bool>
    {
        public async Task<bool> Handle(DeletAssetRepairStatusCommand request, CancellationToken cancellationToken)
        {

            var assetRepairStatusExist = await repairStatusRepository.GetByIdAsync(request.assetRepairId);
            if (assetRepairStatusExist == null) return false;
            return await repairStatusRepository.DeleteAsync(request.assetRepairId, cancellationToken);

        }
    }
}
