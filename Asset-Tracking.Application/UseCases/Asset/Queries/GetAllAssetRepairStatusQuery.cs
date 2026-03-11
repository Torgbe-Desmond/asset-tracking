using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{ 
    public record GetAllAssetRepairStatusQuery()
         : IRequest<List<RepairStatusResponseDto>>;

    public class GetAllAssetRepairStatusdHandler(IRepairStatusRepository repairStatusRepository)
        : IRequestHandler<GetAllAssetRepairStatusQuery, List<RepairStatusResponseDto>>
    {
        public async Task<List<RepairStatusResponseDto>> Handle(
            GetAllAssetRepairStatusQuery request,
            CancellationToken cancellationToken)
        {
            var repairStatuses = await repairStatusRepository.GetAllAsync();

            var dtos = repairStatuses.Select(repairStatus => new RepairStatusResponseDto
            {
                RepairStatusId = repairStatus.RepairStatusId,
                RepairStatusName = repairStatus.RepairStatusName

            }).ToList();

            return dtos;
        }
    }
}
