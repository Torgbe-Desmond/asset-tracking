using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Application.Common.Dtos.Building;
using Asset_Tracking.Application.Common.Dtos.Floor;
using Asset_Tracking.Application.Common.Dtos.Room;
using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{

    public record GetAssetCheckOutByIdQuery(int AssetCheckOutId) : IRequest<AssetCheckoutDetailsDto?>;
    public class GetAssetCheckOutByIdHandler(IAssetCheckOutRepository checkOutRepository) : IRequestHandler<GetAssetCheckOutByIdQuery, AssetCheckoutDetailsDto?>
    {
        public async Task<AssetCheckoutDetailsDto?> Handle(GetAssetCheckOutByIdQuery request, CancellationToken cancellationToken)
        {

            if (request.AssetCheckOutId < 0)
                throw new ArgumentNullException("AssetCheckOutId is required.", nameof(request.AssetCheckOutId));

            var assetCheckOut = await checkOutRepository.GetByIdAsync(request.AssetCheckOutId);

            if (assetCheckOut == null) return null;


            var dtos = new AssetCheckoutDetailsDto
            {
                AssetCheckOutId = assetCheckOut.AssetCheckOutId,
                AssetCheckOutDate = assetCheckOut.AssetCheckOutDate,
                DueDate = assetCheckOut.DueDate,
                Notes = assetCheckOut.Notes,
                CreatedBy = assetCheckOut.CreatedBy,
                UpdatedBy = assetCheckOut.UpdatedBy,
                AssetId = assetCheckOut.AssetId,
                StaffId = assetCheckOut.StaffId,
                AssignedTo = assetCheckOut.AssignedTo,
                SiteId = assetCheckOut.SiteId,
                BuildingId = assetCheckOut.BuildingId,
                FloorId = assetCheckOut.FloorId,
                RoomId = assetCheckOut.RoomId,
                RoomLocationDescription = assetCheckOut.RoomLocationDescription,
                IsConfirmedEmailSent = assetCheckOut.IsConfirmedEmailSent,
                EmailSentDate = assetCheckOut.EmailSentDate,
                HasReceivedConfirmed = assetCheckOut.HasReceivedConfirmed,
                HasReceivedConfirmedDate = assetCheckOut.HasReceivedConfirmedDate,
                IsSMSSent = assetCheckOut.IsSMSSent,
                SMSSentDate = assetCheckOut.SMSSentDate,

                Asset = assetCheckOut.Asset != null ? new  AssetDto 
                {
                    AssetId = assetCheckOut.Asset.AssetId,
                    AssetName = assetCheckOut.Asset.AssetName,
                    AssetTagId = assetCheckOut.Asset.AssetTagId,
                    SerialNumber = assetCheckOut.Asset.SerialNumber,
                    AssetDescription = assetCheckOut.Asset.AssetDescription,
                    PurchaseFrom = assetCheckOut.Asset.PurchaseFrom,
                    PurchaseDate = assetCheckOut.Asset.PurchaseDate,
                    Cost = assetCheckOut.Asset.Cost,
                    Brand = assetCheckOut.Asset.Brand,
                    Model = assetCheckOut.Asset.Model,
                    AssignedTo = assetCheckOut.Asset.AssignedTo,
                    HasWarranty = assetCheckOut.Asset.HasWarranty,
                    WarrantyDate = assetCheckOut.Asset.WarrantyDate,
                    AssetCategoryId = assetCheckOut.Asset.AssetCategoryId,
                    AssetStatusId = assetCheckOut.Asset.AssetStatusId,
                    SiteId = assetCheckOut.Asset.SiteId,
                    BuildingId = assetCheckOut.Asset.BuildingId,
                    FloorId = assetCheckOut.Asset.FloorId,
                    RoomId = assetCheckOut.Asset.RoomId,
                    RoomLocationDescription = assetCheckOut.Asset.RoomLocationDescription,
                    AssetConditionDescription = assetCheckOut.Asset.AssetConditionDescription,
                    IsAssetInGoodCondition = assetCheckOut.Asset.IsAssetInGoodCondition,
                    IsRepairRequired = assetCheckOut.Asset.IsRepairRequired,
                    //DateCreated = assetCheckOut.Asset.DateCreated,
                    CreatedBy = assetCheckOut.Asset.CreatedBy,
                    //DateUpdated = assetCheckOut.Asset.DateUpdated,
                } : null,

                 Site = assetCheckOut.Site != null ? new SiteResponseDto
                 {
                     SiteId = assetCheckOut.Site.SiteId,
                     SiteName = assetCheckOut.Site.SiteName,
                     SiteDescription = assetCheckOut.Site.SiteDescription,
                     Address = assetCheckOut.Site.Address,
                     DigitalAddress = assetCheckOut.Site.DigitalAddress,
                     Email = assetCheckOut.Site.Email,
                     CreatedBy = assetCheckOut.Site.CreatedBy,
                     UpdateBy = assetCheckOut.Site.UpdatedBy
                 } : null,

                Building = assetCheckOut.Building != null ? new BuildingResponseDto
                {
                    BuildingId = assetCheckOut.Building.BuildingId,
                    BuildingName = assetCheckOut.Building.BuildingName,
                    CreatedBy = assetCheckOut.Building.CreatedBy,
                    UpdatedBy = assetCheckOut.Building.UpdatedBy
                } : null,

                Floor = assetCheckOut.Floor != null ? new FloorResponseDto
                {
                    FloorId = assetCheckOut.Floor.FloorId,
                    FloorName = assetCheckOut.Floor.FloorName,
                    CreatedBy = assetCheckOut.Floor.CreatedBy,
                    UpdatedBy = assetCheckOut.Floor.UpdatedBy
                } : null,

                Room = assetCheckOut.Room != null ? new RoomResponseDto
                {
                    RoomId = assetCheckOut.Room.RoomId,
                    RoomName = assetCheckOut.Room.RoomName,
                    CreatedBy = assetCheckOut.Room.CreatedBy,
                    UpdatedBy = assetCheckOut.Room.UpdatedBy
                } : null,

            };

            return dtos;
        }

    }

}