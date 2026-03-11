
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
   
    public record DeleteAssetEventHistoryCommand(string AssetEventHistoryId) : IRequest<bool>;

    public class DeleteAssetEventHistoryHandler(IAssetEventHistoryRepository eventHistoryRepository) : IRequestHandler<DeleteAssetEventHistoryCommand, bool>
    {
        public async Task<bool> Handle(DeleteAssetEventHistoryCommand request, CancellationToken cancellationToken)
        {

            var assetEventHistoryExist = await eventHistoryRepository.GetByIdAsync(request.AssetEventHistoryId);
            if (assetEventHistoryExist == null) return false;
            return await eventHistoryRepository.DeleteAsync(request.AssetEventHistoryId, cancellationToken);

        }
    }
}
