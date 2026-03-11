using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record DeleteAssetDisposeCommand(int assetDisposeId) : IRequest<bool>;
    public class DeleteAssetDisposeHandler(IAssetDisposeRepository disposeRepository) : IRequestHandler<DeleteAssetDisposeCommand, bool>
    {
        public async Task<bool> Handle(DeleteAssetDisposeCommand request, CancellationToken cancellationToken)
        {

            var assetExist = await disposeRepository.GetByIdAsync(request.assetDisposeId);
            if (assetExist == null) return false;
            return await disposeRepository.DeleteAsync(request.assetDisposeId, cancellationToken);

        }
    }
}
