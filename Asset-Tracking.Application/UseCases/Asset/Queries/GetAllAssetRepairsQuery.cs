using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetAllAssetRepairsQuery() : IRequest<List<AssetRepairDetailResponseDto>>;
    public class GetAllAssetRepairsHandler(IAssetRepairRepository assetRepairRepository) : IRequestHandler<GetAllAssetRepairsQuery, List<AssetRepairDetailResponseDto>>
    {
        public async Task<List<AssetRepairDetailResponseDto>> Handle(GetAllAssetRepairsQuery request, CancellationToken cancellationToken)
        {

            var assetRepairs = await assetRepairRepository.GetAllAsync();

            var dtos = assetRepairs.Select(assetRepair => new AssetRepairDetailResponseDto()
            {
                AssetRepairId = assetRepair.AssetRepairId,
                RepairTitle = assetRepair.RepairTitle.Trim(),
                Details = assetRepair.Details.Trim(),
                RepairerName = assetRepair.RepairerName?.Trim(),
                RepairerContactNumber = assetRepair.RepairerContactNumber?.Trim(),
                Cost = assetRepair.Cost,
                DateCompleted = assetRepair.DateCompleted?.Trim(),
                RepairStatusId = assetRepair.RepairStatusId,
                AssetReceiveDate = assetRepair.AssetReceiveDate,
                ReceivedBy = assetRepair.ReceivedBy?.Trim(),
                CreatedBy = assetRepair.CreatedBy,
                //DateCreated = assetRepair.DateCreated,
                UpdateBy = assetRepair.UpdateBy,
                //DateUpdated = assetRepair.DateUpdated,
            }).ToList();

            return dtos;
        }
    }
}
