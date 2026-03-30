using Asset_Tracking.Application.Common.Dtos.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetRepairStatusByIdQuery(int RepairStatusId)
         : IRequest<RepairStatusResponseDto?>;

    public class GetRepairStatusByIdHandler(IRepairStatusRepository repairStatusRepository)
        : IRequestHandler<GetRepairStatusByIdQuery, RepairStatusResponseDto?>
    {
        public async Task<RepairStatusResponseDto?> Handle(
            GetRepairStatusByIdQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await repairStatusRepository.GetByIdAsync(request.RepairStatusId);

            if (entity is null) return null!;

            return new RepairStatusResponseDto
            {
                RepairStatusId = entity.RepairStatusId,
                RepairStatusName = entity.RepairStatusName,
            };
        }
    }
}
