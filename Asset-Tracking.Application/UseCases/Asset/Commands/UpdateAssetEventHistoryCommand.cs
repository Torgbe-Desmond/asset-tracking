using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Entities;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Commands
{

    public record UpdateAssetEventHistoryCommand(string AssetEventHistoryId, AssetEventHistoryRequestDto AssetEventHistory) : IRequest<bool>;

    public class UpdateAssetEventHistoryHandler(IAssetEventHistoryRepository eventHistoryRepository) : IRequestHandler<UpdateAssetEventHistoryCommand, bool>
    {
        public async Task<bool> Handle(UpdateAssetEventHistoryCommand request, CancellationToken cancellationToken)
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
                Date = DateTime.UtcNow,
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

            return await eventHistoryRepository.UpdateAsync(request.AssetEventHistoryId, history);

            
        }
    }
}
