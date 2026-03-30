using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAllAssetCheckOutQuery() : IRequest<List<AssetCheckOutResponseDto>>;
    public class GetAllAssetCheckOutHandler(IAssetCheckOutRepository checkOutRepository) : IRequestHandler<GetAllAssetCheckOutQuery, List<AssetCheckOutResponseDto>>
    {
        public async Task<List<AssetCheckOutResponseDto>> Handle(GetAllAssetCheckOutQuery request, CancellationToken cancellationToken)
        {
            var assetCheckOuts = await checkOutRepository.GetAllAsync();

            if (assetCheckOuts == null)
                throw new ArgumentNullException("No asset checkouts found.", nameof(assetCheckOuts));

            var dtos = assetCheckOuts.Select(assetCheckOut => new AssetCheckOutResponseDto
            {
                AssetCheckOutId = assetCheckOut.AssetCheckOutId,
                AssetCheckOutDate = assetCheckOut.AssetCheckOutDate,
                DueDate = assetCheckOut.DueDate,
                Notes = assetCheckOut.Notes,
                //DateCreated = assetCheckOut.DateCreated,
                CreatedBy = assetCheckOut.CreatedBy,
                //DateUpdated = assetCheckOut.DateUpdated,
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
                SMSSentDate = assetCheckOut.SMSSentDate
            }).ToList();

            return dtos;
        }


    }
}
