using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddAssetDisposeCommand(AssetDisposeRequestDto AssetDispose): IRequest<AssetDisposeResponseDto>;

    public class AddAssetDisposeHandler(IAssetDisposeRepository disposeRepository) : IRequestHandler<AddAssetDisposeCommand, AssetDisposeResponseDto>
    {
        public async Task<AssetDisposeResponseDto> Handle(AddAssetDisposeCommand request, CancellationToken cancellationToken)
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

            await disposeRepository.AddAsync(dispose);

            return new AssetDisposeResponseDto
            {
                AssetDisposeId = dispose.AssetDisposeId,
                DisposeDate = dispose.DisposeDate,
                DisposeTo = dispose.DisposeTo,
                Notes = dispose.Notes,
                //DateCreated = dispose.DateCreated,
                CreatedBy = dispose.CreatedBy,
                //DateUpdated = dispose.DateUpdated,
                //UpdatedBy = dispose.UpdatedBy,
                AssetId = dispose.AssetId
            };

        }
    }


}
