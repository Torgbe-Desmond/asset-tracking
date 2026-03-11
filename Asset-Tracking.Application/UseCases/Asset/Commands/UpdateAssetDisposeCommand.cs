using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record UpdateAssetDisposeCommand(int AssetDisposeId,AssetDisposeRequestDto AssetDispose) : IRequest<bool>;

    public class UpdateAssetDisposeHandler(IAssetDisposeRepository disposeRepository) : IRequestHandler<UpdateAssetDisposeCommand, bool>
    {

        public async Task<bool> Handle(UpdateAssetDisposeCommand request, CancellationToken cancellationToken)
        {
            var dto = request.AssetDispose;

            if (!string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("CreatedBy is required.");


            var dispose = new AssetDisposeEntity
            {
                DisposeDate = dto.DisposeDate,
                DisposeTo = dto.DisposeTo.Trim(),
                Notes = dto.Notes?.Trim(),
                DateCreated = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy.Trim(),
                DateUpdated = null,
                UpdatedBy = null,
                AssetId = dto.AssetId,
            };

            return await disposeRepository.UpdateAsync(request.AssetDisposeId,dispose, cancellationToken);
        }
    }
}
