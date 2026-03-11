using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record UpdateAssetCheckInsCommand(int AssetCheckInId, AssetCheckInRequestDto CheckIn) : IRequest<bool>;
    public class UpdateAssetCheckInsHandler(IAssetCheckInRepository checkInRepository) : IRequestHandler<UpdateAssetCheckInsCommand, bool>
    {

        public async Task<bool> Handle(
            UpdateAssetCheckInsCommand request,
            CancellationToken cancellationToken)
        {
            var dto = request.CheckIn;

            if (dto.ReturnDate == default)
                throw new ArgumentException("Return date is required.", nameof(dto.ReturnDate));

            if (string.IsNullOrWhiteSpace(dto.ReturnedBy))
                throw new ArgumentException("ReturnedBy is required.", nameof(dto.ReturnedBy));

            if (string.IsNullOrWhiteSpace(dto.CreatedBy))
                throw new ArgumentException("CreatedBy is required.", nameof(dto.CreatedBy));

            if (dto.AssetId <= 0)
                throw new ArgumentException("Valid AssetId is required.", nameof(dto.AssetId));
             
            var assetExists = await checkInRepository.GetByIdAsync(request.AssetCheckInId);

            if(assetExists != null)
                throw new KeyNotFoundException("Asset not found.");

            var entity = new AssetCheckInEntity
            {
                ReturnDate = dto.ReturnDate,
                Notes = dto.Notes?.Trim(),
                ReturnedBy = dto.ReturnedBy.Trim(),
                StaffId = dto.StaffId?.Trim(),
                DateCreated = DateTime.UtcNow,
                CreatedBy = dto.CreatedBy.Trim(),
                DateUpdated = dto.DateUpdated,
                UpdatedBy = dto.UpdatedBy?.Trim(),
                AssetId = dto.AssetId,
                SiteId = dto.SiteId
            };


            return await checkInRepository.UpdateAsync(request.AssetCheckInId, entity, cancellationToken);

        }
    }
}
