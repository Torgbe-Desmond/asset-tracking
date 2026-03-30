using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{

    public record GetAllAssetCheckInQuery() : IRequest<List<AssetCheckInResponseDto>>;
    public class GetAllAssetCheckInHandler(IAssetCheckInRepository checkInRepository) : IRequestHandler<GetAllAssetCheckInQuery, List<AssetCheckInResponseDto>>
    {
        public async Task<List<AssetCheckInResponseDto>> Handle(GetAllAssetCheckInQuery request, CancellationToken cancellationToken)
        {
            var assetCheckIns =  await checkInRepository.GetAllAsync();

            if (assetCheckIns == null)
                throw new ArgumentNullException("No asset checkins found.", nameof(assetCheckIns));

            var dtos = assetCheckIns.Select(assetCheckIn => new AssetCheckInResponseDto
            {
                AssetCheckInId = assetCheckIn.AssetCheckInId,
                ReturnDate = assetCheckIn.ReturnDate,
                Notes = assetCheckIn.Notes,
                ReturnedBy = assetCheckIn.ReturnedBy,
                StaffId = assetCheckIn.StaffId,
                CreatedBy = assetCheckIn.CreatedBy,
                UpdatedBy = assetCheckIn.UpdatedBy,
                AssetId = assetCheckIn.AssetId,
                SiteId = assetCheckIn.SiteId
            }).ToList();

            return dtos;
        }

      
    }
}
