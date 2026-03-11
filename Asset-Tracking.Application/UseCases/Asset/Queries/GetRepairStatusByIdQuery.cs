using Asset_Tracking.Application.Common.Asset;
using Asset_Tracking.Domain.Interfaces;
using MediatR;

namespace Asset_Tracking.Application.UseCases.Asset.Queries
{
    public record GetRepairStatusByIdQuery(int RepairStatusId)
         : IRequest<RepairStatusResponseDto>;

    public class GetRepairStatusByIdHandler(IRepairStatusRepository repairStatusRepository)
        : IRequestHandler<GetRepairStatusByIdQuery, RepairStatusResponseDto>
    {
        public async Task<RepairStatusResponseDto> Handle(
            GetRepairStatusByIdQuery request,
            CancellationToken cancellationToken)
        {
            if (request.RepairStatusId <= 0)
                throw new ArgumentException("RepairStatusId is required.");

            var entity = await repairStatusRepository.GetByIdAsync(request.RepairStatusId);

            if (entity is null)
                throw new KeyNotFoundException("Repair status not found.");

            return new RepairStatusResponseDto
            {
                RepairStatusId = entity.RepairStatusId,
                RepairStatusName = entity.RepairStatusName,
            };
        }
    }
}
