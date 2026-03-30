using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddAssetCategoryCommand(AssetCategoryRequestDto Category) : IRequest<AssetCategoryResponseDto>;
    public class AddAssetCategoryHandler(IAssetCategoryRepository categoryRepository) : IRequestHandler<AddAssetCategoryCommand, AssetCategoryResponseDto>
    {
        public async Task<AssetCategoryResponseDto> Handle(
            AddAssetCategoryCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.Category;

            // Basic validation (strongly recommend moving to FluentValidation)
            if (string.IsNullOrWhiteSpace(dto.AssetCategoryName))
                throw new ArgumentException("AssetCategoryName is required.", nameof(dto.AssetCategoryName));

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("CreatedBy is required.", nameof(dto.CreatedBy));

            var entity = new AssetCategoryEntity
            {
                AssetCategoryName = dto.AssetCategoryName.Trim(),
                DateCreated = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy.Trim(),
                DateUpdated = dto.DateUpdated,
                UpdatedBy = dto.UpdatedBy?.Trim()
            };

            await categoryRepository.AddAsync(entity, cancellationToken);

            return new AssetCategoryResponseDto
            {
                AssetCategoryId = entity.AssetCategoryId,
                AssetCategoryName = entity.AssetCategoryName,
                CreatedBy = entity.CreatedBy,
                UpdatedBy = entity.UpdatedBy
            };
        }
    }
}
