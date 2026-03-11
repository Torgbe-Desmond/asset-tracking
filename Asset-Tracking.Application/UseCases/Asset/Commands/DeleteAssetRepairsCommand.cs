using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record DeleteAssetRepairsCommand(int assetRepairId) : IRequest<bool>;

    public class DeleteAssetRepairsHandler(IAssetRepairRepository assetRepairRepository) : IRequestHandler<DeleteAssetRepairsCommand, bool>
    {
        public async Task<bool> Handle(DeleteAssetRepairsCommand request, CancellationToken cancellationToken)
        {

            var assetRepairExist = await assetRepairRepository.GetByIdAsync(request.assetRepairId);
            if (assetRepairExist == null) return false;
            return await assetRepairRepository.DeleteAsync(request.assetRepairId, cancellationToken);

        }
    }
}
