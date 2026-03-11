using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{
    public record AddAssetEventHistoryCommand(AssetEventHistoryRequestDto AssetEventHistory): IRequest<AssetEventHistoryResponseDto>;

    public class AddAssetEventHistoryHandler(IAssetEventHistoryRepository eventHistoryRepository) : IRequestHandler<AddAssetEventHistoryCommand, AssetEventHistoryResponseDto>
    {
        public async Task<AssetEventHistoryResponseDto> Handle(AddAssetEventHistoryCommand request, CancellationToken cancellationToken)
        {
            var dto = request.AssetEventHistory;

            if (string.IsNullOrWhiteSpace(dto.Event))
                throw new ArgumentException("Event is required.");

            if (string.IsNullOrWhiteSpace(dto.StatusChangedFrom))
                throw new ArgumentException("Status name is required.");

            if (string.IsNullOrWhiteSpace(dto.StatusChangeTo))
                throw new ArgumentException("StatusChangeT is required.");

            if (dto.AssetId < 0)
                throw new ArgumentException("AssetId is required.");

            var history = new AssetEventHistoryEntity
            {
                Date =  DateTime.UtcNow,
                Event = dto.Event.Trim(),
                StatusChangedFrom = dto.StatusChangedFrom.Trim(),
                StatusChangeTo = dto.StatusChangeTo.Trim(),
                LocationChangedFrom = dto.LocationChangedFrom?.Trim(),
                LocationChangedTo = dto.LocationChangedTo?.Trim(),
                SiteChangedFrom = dto.SiteChangedFrom?.Trim(),
                SiteChangedTo = dto.SiteChangedTo?.Trim(),
                AssignedFrom = dto.AssignedFrom?.Trim(),
                AssignedTo = dto.AssignedTo?.Trim(),
                AssetId = dto.AssetId,
            };

            await eventHistoryRepository.AddAsync(history);

            return new AssetEventHistoryResponseDto
            {
                AssetEventHistoryId = history.AssetEventHistoryId,
                Date = history.Date,
                Event = history.Event,
                StatusChangedFrom = history.StatusChangedFrom,
                StatusChangeTo = history.StatusChangeTo,
                LocationChangedFrom = history.LocationChangedFrom,
                LocationChangedTo = history.LocationChangedTo,
                SiteChangedFrom = history.SiteChangedFrom,
                SiteChangedTo = history.SiteChangedTo,
                AssignedFrom = history.AssignedFrom,
                AssignedTo = history.AssignedTo,
                AssetId = history.AssetId
            };
        }
    }

}
