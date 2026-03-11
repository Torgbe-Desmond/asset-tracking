using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Application.Common.Building;
using Asset_Tracking.Application.Common.Floor;
using Asset_Tracking.Application.Common.Room;
using Asset_Tracking.Application.Common.Site;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{

    public record GetAssetByIdQuery(int AssetId) : IRequest<AssetDetailDto>;
    public class GetAssetHandler(IAssetRepository assetRepository) : IRequestHandler<GetAssetByIdQuery, AssetDetailDto>
    {
        public async Task<AssetDetailDto> Handle(
            GetAssetByIdQuery request,
            CancellationToken cancellationToken)
        {

            if (request.AssetId < 0)
                throw new ArgumentNullException("AssetCheckInId is required.", nameof(request.AssetId));

            var asset = await assetRepository.GetByIdAsync(request.AssetId);

            if (asset == null)
                throw new KeyNotFoundException("No asset checkin found.");

            var dtos = new AssetDetailDto
            {
                AssetId = asset.AssetId,
                AssetName = asset.AssetName,
                AssetTagId = asset.AssetTagId,
                SerialNumber = asset.SerialNumber,
                AssetDescription = asset.AssetDescription,
                PurchaseFrom = asset.PurchaseFrom,
                PurchaseDate = asset.PurchaseDate,
                Cost = asset.Cost,
                Brand = asset.Brand,
                Model = asset.Model,
                AssignedTo = asset.AssignedTo,
                HasWarranty = asset.HasWarranty,
                WarrantyDate = asset.WarrantyDate,
                AssetCategoryId = asset.AssetCategoryId,
                AssetStatusId = asset.AssetStatusId,
                SiteId = asset.SiteId,
                BuildingId = asset.BuildingId,
                FloorId = asset.FloorId,
                RoomId = asset.RoomId,
                RoomLocationDescription = asset.RoomLocationDescription,
                AssetConditionDescription = asset.AssetConditionDescription,
                IsAssetInGoodCondition = asset.IsAssetInGoodCondition,
                IsRepairRequired = asset.IsRepairRequired,
                //DateCreated = asset.DateCreated,
                CreatedBy = asset.CreatedBy,

                // Nested DTOs – flattened from navigation properties
                AssetCategory = asset.AssetCategory != null ? new AssetCategoryResponseDto
                {
                    AssetCategoryId = asset.AssetCategory.AssetCategoryId,
                    AssetCategoryName = asset.AssetCategory.AssetCategoryName,
                    //DateCreated = asset.AssetCategory.DateCreated,
                    CreatedBy = asset.AssetCategory.CreatedBy,
                    //DateUpdated = asset.AssetCategory.DateUpdated,
                    UpdatedBy = asset.AssetCategory.UpdatedBy
                } : null,

                AssetStatus = asset.AssetStatus != null ? new AssetStatusResponseDto
                {
                    AssetStatusId = asset.AssetStatus.AssetStatusId,
                    AssetStatusName = asset.AssetStatus.AssetStatusName,
                    //DateCreated = asset.AssetStatus.DateCreated,
                    CreatedBy = asset.AssetStatus.CreatedBy,
                    //DateUpdated = asset.AssetStatus.DateUpdated,
                    UpdatedBy = asset.AssetStatus.UpdatedBy
                } : null,

                Site = asset.Site != null ? new SiteResponseDto
                {
                    SiteId = asset.Site.SiteId,
                    SiteName = asset.Site.SiteName,
                    SiteDescription = asset.Site.SiteDescription,
                    Address = asset.Site.Address,
                    DigitalAddress = asset.Site.DigitalAddress,
                    Email = asset.Site.Email,
                    //DateCreated = asset.Site.DateCreated,
                    CreatedBy = asset.Site.CreatedBy,
                    //DateUpdated = asset.Site.DateUpdated,
                    UpdateBy = asset.Site.UpdatedBy
                } : null,

                Building = asset.Building != null ? new BuildingResponseDto
                {
                    BuildingId = asset.Building.BuildingId,
                    BuildingName = asset.Building.BuildingName,
                    //CreatedDate = asset.Building.CreatedDate,
                    CreatedBy = asset.Building.CreatedBy,
                    //UpdatedDate = asset.Building.UpdatedDate,
                    UpdatedBy = asset.Building.UpdatedBy
                } : null,

                Floor = asset.Floor != null ? new FloorResponseDto
                {
                    FloorId = asset.Floor.FloorId,
                    FloorName = asset.Floor.FloorName,
                    //CreatedDate = asset.Floor.CreatedDate,
                    CreatedBy = asset.Floor.CreatedBy,
                    //UpdatedDate = asset.Floor.UpdatedDate,
                    UpdatedBy = asset.Floor.UpdatedBy
                } : null,

                Room = asset.Room != null ? new RoomResponseDto
                {
                    RoomId = asset.Room.RoomId,
                    RoomName = asset.Room.RoomName,
                    //CreatedDate = asset.Room.CreatedDate,
                    CreatedBy = asset.Room.CreatedBy,
                    //UpdatedDate = asset.Room.UpdatedDate,
                    UpdatedBy = asset.Room.UpdatedBy
                } : null,

                AssetImage = asset.AssetImage != null ? new AssetImageResponseDto
                {
                    AssetImageId = asset.AssetImage.AssetImageId,
                    Photo = asset.AssetImage.Photo
                } : null

            };

            return dtos;

        }
    }
}
