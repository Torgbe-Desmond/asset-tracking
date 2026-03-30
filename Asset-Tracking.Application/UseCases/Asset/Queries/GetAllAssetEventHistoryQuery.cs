using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAllAssetEventHistoryQuery() : IRequest<List<AssetEventHistoryResponseDto>>;

    public class GetAllAssetEventHistoryHandler(IAssetEventHistoryRepository eventHistoryRepository) : IRequestHandler<GetAllAssetEventHistoryQuery, List<AssetEventHistoryResponseDto>>
    {
        public async Task<List<AssetEventHistoryResponseDto>> Handle(GetAllAssetEventHistoryQuery request, CancellationToken cancellationToken)
        {

            var eventHistories =  await eventHistoryRepository.GetAllAsync();

            var dtos = eventHistories.Select(eventHistory => new AssetEventHistoryResponseDto
            {
                AssetEventHistoryId = eventHistory.AssetEventHistoryId,
                Date = eventHistory.Date,
                Event = eventHistory.Event,
                StatusChangedFrom = eventHistory.StatusChangedFrom,
                StatusChangeTo = eventHistory.StatusChangeTo,
                LocationChangedFrom = eventHistory.LocationChangedFrom,
                LocationChangedTo = eventHistory.LocationChangedTo,
                SiteChangedFrom = eventHistory.SiteChangedFrom,
                SiteChangedTo = eventHistory.SiteChangedTo,
                AssignedFrom = eventHistory.AssignedFrom,
                AssignedTo = eventHistory.AssignedTo,
                AssetId = eventHistory.AssetId

            }).ToList();

            return dtos;
        }

    }
}
