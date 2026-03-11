using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAssetEventHistoryByIdQuery(string AssetEventHistoryId) : IRequest<AssetEventHistoryDetailsResponseDto>;

    public class GetAssetEventHistoryDetailsHandler(IAssetEventHistoryRepository eventHistoryRepository) : IRequestHandler<GetAssetEventHistoryByIdQuery, AssetEventHistoryDetailsResponseDto>
    {
        public async Task<AssetEventHistoryDetailsResponseDto> Handle(GetAssetEventHistoryByIdQuery request, CancellationToken cancellationToken)
        {


            if (request.AssetEventHistoryId == null)
                throw new ArgumentNullException("AssetEventHistoryId is required.", nameof(request.AssetEventHistoryId));

            var eventHistory = await eventHistoryRepository.GetByIdAsync(request.AssetEventHistoryId);

            if (eventHistory == null)
                throw new KeyNotFoundException("No event history found.");

            var dtos = new AssetEventHistoryDetailsResponseDto()
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
                AssetId = eventHistory.AssetId,

                Asset = eventHistory.Asset != null ? new AssetDto
                  {
                      AssetId = eventHistory.Asset.AssetId,
                      AssetName = eventHistory.Asset.AssetName ?? string.Empty,
                      AssetDescription = eventHistory.Asset.AssetDescription,
                      PurchaseFrom = eventHistory.Asset.PurchaseFrom,
                      PurchaseDate = eventHistory.Asset.PurchaseDate,
                      Cost = eventHistory.Asset.Cost,
                      Brand = eventHistory.Asset.Brand,
                      Model = eventHistory.Asset.Model,
                      SerialNumber = eventHistory.Asset.SerialNumber,
                      AssignedTo = eventHistory.Asset.AssignedTo,
                      HasWarranty = eventHistory.Asset.HasWarranty,
                      WarrantyDate = eventHistory.Asset.WarrantyDate,
                      AssetCategoryId = eventHistory.Asset.AssetId,
                      AssetStatusId = eventHistory.Asset.AssetId,
                      AssetImageId = eventHistory.Asset.AssetId,
                      SiteId = eventHistory.Asset.AssetId,
                      BuildingId = eventHistory.Asset.AssetId,
                      FloorId = eventHistory.Asset.FloorId,
                      RoomId = eventHistory.Asset.AssetId,
                      RoomLocationDescription = eventHistory.Asset.RoomLocationDescription,
                      AssetTagId = eventHistory.Asset.AssetTagId ?? string.Empty,
                      AssetConditionDescription = eventHistory.Asset.AssetConditionDescription,
                      IsAssetInGoodCondition = eventHistory.Asset.IsAssetInGoodCondition,
                      IsRepairRequired = eventHistory.Asset.IsRepairRequired,
                      //DateCreated = eventHistory.Asset.DateCreated,
                      CreatedBy = eventHistory.Asset.CreatedBy,
                      //DateUpdated = eventHistory.Asset.DateUpdated,
                } : null,

            };

            return dtos;
        }

    }

}
