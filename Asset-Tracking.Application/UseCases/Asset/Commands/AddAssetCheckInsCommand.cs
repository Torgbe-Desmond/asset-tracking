using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddAssetCheckInsCommand(AssetCheckInRequestDto CheckIn) : IRequest<AssetCheckInResponseDto>;
    public class AddAssetCheckInsHandler(IAssetCheckInRepository checkInRepository) : IRequestHandler<AddAssetCheckInsCommand, AssetCheckInResponseDto>
    {
       
        public async Task<AssetCheckInResponseDto> Handle(
            AddAssetCheckInsCommand request,
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

        
            await checkInRepository.AddAsync(entity, cancellationToken);

            return new AssetCheckInResponseDto
            {
                AssetCheckInId = entity.AssetCheckInId,
                ReturnDate = entity.ReturnDate,
                Notes = entity.Notes,
                ReturnedBy = entity.ReturnedBy,
                StaffId = entity.StaffId,
                //DateCreated = entity.DateCreated,
                //CreatedBy = entity.CreatedBy,
                //DateUpdated = entity.DateUpdated,
                //UpdatedBy = entity.UpdatedBy,
                AssetId = entity.AssetId,
                SiteId = entity.SiteId
            };
        }
    }
}