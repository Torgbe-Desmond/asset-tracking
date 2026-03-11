using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record DeleteAssetCheckInsCommand(int assetCheckInId) : IRequest<bool>;

    public class DeleteAssetChecInsHandler(IAssetCheckInRepository assetCheckInsRepository) : IRequestHandler<DeleteAssetCheckInsCommand, bool>
    {
        public async Task<bool> Handle(DeleteAssetCheckInsCommand request, CancellationToken cancellationToken)
        {

            var assetExist = await assetCheckInsRepository.GetByIdAsync(request.assetCheckInId);
            if (assetExist == null)
            {
                throw new KeyNotFoundException($"AssetCheckIns with ID {request.assetCheckInId} not found.");
            }

            return await assetCheckInsRepository.DeleteAsync(request.assetCheckInId, cancellationToken);

        }
    }
}
