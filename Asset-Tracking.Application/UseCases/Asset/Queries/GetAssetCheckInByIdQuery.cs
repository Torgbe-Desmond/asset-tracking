using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Application.Common.Dtos.Site;
using Asset_Tracking.Application.Common.Dtos.Staff;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{

    public record GetAllAssetCheckInByIdQuery(int AssetCheckInId) : IRequest<AssetCheckInDetailsResponseDto?>;
    public class GetAllAssetCheckInByIdHandler(IAssetCheckInRepository checkInRepository) : IRequestHandler<GetAllAssetCheckInByIdQuery, AssetCheckInDetailsResponseDto?>
    {
        public async Task<AssetCheckInDetailsResponseDto?> Handle(GetAllAssetCheckInByIdQuery request, CancellationToken cancellationToken)
        {

            if (request.AssetCheckInId < 0)
                throw new ArgumentNullException("AssetCheckInId is required.", nameof(request.AssetCheckInId));

            var assetCheckIns = await checkInRepository.GetByIdAsync(request.AssetCheckInId);

            if (assetCheckIns == null) return null;


            return new AssetCheckInDetailsResponseDto()
            {
                AssetCheckInId = assetCheckIns.AssetCheckInId,
                ReturnDate = assetCheckIns.ReturnDate,
                Notes = assetCheckIns.Notes,
                ReturnedBy = assetCheckIns.ReturnedBy,
                StaffId = assetCheckIns.StaffId,
                CreatedBy = assetCheckIns.CreatedBy,
                UpdatedBy = assetCheckIns.UpdatedBy,
                AssetId = assetCheckIns.AssetId,
                SiteId = assetCheckIns.SiteId,

                Asset = assetCheckIns.Asset != null ? new AssetDto
                {
                    AssetId = assetCheckIns.Asset.AssetId,
                    AssetName = assetCheckIns.Asset.AssetName ?? string.Empty, 
                    AssetDescription = assetCheckIns.Asset.AssetDescription,
                    PurchaseFrom = assetCheckIns.Asset.PurchaseFrom,
                    PurchaseDate = assetCheckIns.Asset.PurchaseDate,
                    Cost = assetCheckIns.Asset.Cost,
                    Brand = assetCheckIns.Asset.Brand,
                    Model = assetCheckIns.Asset.Model,
                    SerialNumber = assetCheckIns.Asset.SerialNumber,
                    AssignedTo = assetCheckIns.Asset.AssignedTo,
                    HasWarranty = assetCheckIns.Asset.HasWarranty,
                    WarrantyDate = assetCheckIns.Asset.WarrantyDate,
                    AssetCategoryId = assetCheckIns.Asset.AssetCategoryId,
                    AssetStatusId = assetCheckIns.Asset.AssetStatusId,
                    AssetImageId = assetCheckIns.Asset.AssetImageId,
                    SiteId = assetCheckIns.Asset.SiteId,
                    BuildingId = assetCheckIns.Asset.BuildingId,
                    FloorId = assetCheckIns.Asset.FloorId,
                    RoomId = assetCheckIns.Asset.RoomId,
                    RoomLocationDescription = assetCheckIns.Asset.RoomLocationDescription,
                    AssetTagId = assetCheckIns.Asset.AssetTagId ?? string.Empty, 
                    AssetConditionDescription = assetCheckIns.Asset.AssetConditionDescription,
                    IsAssetInGoodCondition = assetCheckIns.Asset.IsAssetInGoodCondition,
                    IsRepairRequired = assetCheckIns.Asset.IsRepairRequired,
                    CreatedBy = assetCheckIns.Asset.CreatedBy,

                } : null,

                Site = assetCheckIns.Site != null ? new SiteResponseDto
                {
                    SiteId = assetCheckIns.Site.SiteId,
                    SiteName = assetCheckIns.Site.SiteName,
                    SiteDescription = assetCheckIns.Site.SiteDescription,
                    Address = assetCheckIns.Site.Address,
                    DigitalAddress = assetCheckIns.Site.DigitalAddress,
                    Email = assetCheckIns.Site.Email,
                    CreatedBy = assetCheckIns.Site.CreatedBy,

                  
                } : null,

                Staff = assetCheckIns.Staff != null ? new StaffResponseDto
                {
                    StaffId = assetCheckIns.Staff.StaffId,
                    TitleId = assetCheckIns.Staff.TitleId,
                    Surname = assetCheckIns.Staff.Surname,
                    OtherName = assetCheckIns.Staff.OtherName,
                    TechMail = assetCheckIns.Staff.TechMail,
                    SiteId = assetCheckIns.Staff.SiteId,
                    BuildingId = assetCheckIns.Staff.BuildingId,
                    FloorId = assetCheckIns.Staff.FloorId,
                    RoomId = assetCheckIns.Staff.RoomId,
                    HasRoom = assetCheckIns.Staff.HasRoom,
                    RoomLocationDescription = assetCheckIns.Staff.RoomLocationDescription
                } : null,


            };

        }

      
    }
}
